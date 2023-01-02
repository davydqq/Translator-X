using ConsoleTables;
using CQRS.Commands;
using CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using TB.Common;
using TB.ComputerVision;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Texts.Commands;
using TB.Translator;
using TB.Translator.Entities;
using TB.User;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TB.Images.Commands;

public class HandleImagesCommandHandler : ICommandHandler<HandleImagesCommand>
{
    private readonly ILogger<HandleImagesCommandHandler> logger;

    private readonly IComputerVisionService computerVisionService;

    private readonly IQueryDispatcher queryDispatcher;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ITranslateService translateService;

    private readonly IUserService userService;

    private readonly IRepository<Language, LanguageENUM> langRepository;

    private readonly ILocalizationService localizationService;

    private readonly UserSettingsRepository userSettingsRepository;

    private readonly string[] supportedFormats = PhotosExtension.GetFormats();

    private int four_mb = 4194304;

    public HandleImagesCommandHandler(
        ILogger<HandleImagesCommandHandler> logger, 
        IComputerVisionService computerVisionService,
        IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService,
        IUserService userService,
        IRepository<Language, LanguageENUM> langRepository,
        ILocalizationService localizationService,
        UserSettingsRepository userSettingsRepository)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.queryDispatcher = queryDispatcher;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
        this.userService = userService;
        this.langRepository = langRepository;
        this.localizationService = localizationService;
        this.userSettingsRepository = userSettingsRepository;
    }

    public async Task HandleAsync(HandleImagesCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);
        if (!res) return;

        var file = command.Files.Where(x => x.Size < four_mb).MaxBy(x => x.Size);
        if(file == null)
        {
            var text = await localizationService.GetTranslateByInterface("app.photo.tooLargeFile", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return;
        }

        var downloadFile = await queryDispatcher.DispatchAsync(new DownloadFileQuery(file.TelegramFileId));

        var extension = Path.GetExtension(downloadFile.Path);
        if (!supportedFormats.Any(x => x == extension))
        {
            var text = await localizationService.GetTranslateByInterface("app.photo.noSupportFormat", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return;
        }

        await ProcessCaptions(command.ChatId, command.UserId, command.MessageId, command.Caption, command.MessageId);

        var res1 = await ProcessAndSendOCRResultsAsync(downloadFile.File, command.ChatId, command.UserId, command.MessageId);
        if (!res1)
        {
            await SendErrorMessage(command.ChatId, command.MessageId, command.UserId);
            return;
        }

        var res2 = await ProcessAndSendPhotoAnalysisAsync(downloadFile.File, command.ChatId, command.UserId, command.MessageId);
        if (!res2)
        {
            await SendErrorMessage(command.ChatId, command.MessageId, command.UserId);
        }
    }

    private async Task SendErrorMessage(long chatId, int replyId, long userId)
    {
        var errorText = await localizationService.GetTranslateByInterface("app.photo.cantProcess", userId);
        var commandTelegram = new SendMessageCommand(chatId, errorText, parseMode: ParseMode.Html, replyToMessageId: replyId);
        await commandDispatcher.DispatchAsync(commandTelegram);
    }

    private async Task ProcessCaptions(long chatId, long userId, int messageId, string caption, int replyId)
    {
        if (!string.IsNullOrEmpty(caption))
        {
            var command = new HandleTextsCommand(chatId, userId, messageId, caption, replyId);
            await commandDispatcher.DispatchAsync(command);
        }
    }

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await computerVisionService.AnalyzeImageAsync(bytes);

        if (results == null || !results.isSuccess) return false;

        //
        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(userId);

        var resText = "";

        var tags = results.Tags?.Select(x => x.Name) ?? new List<string>();
        var descriptionTags = results.Description?.Tags ?? new List<string>();

        var resTags = tags.Union(descriptionTags).Distinct();

        if (resTags != null && resTags.Any())
        {
            var imageObjectsMessage = await localizationService.GetTranslateByInterface("app.images.objects", userId);
            var text = $"{imageObjectsMessage}\n\n";

            text += await ProccessTagsResponse(resTags, settings);

            resText += text;
        }

        if (results.Description != null)
        {
            var captions = results.Description.Captions.Select(x => x.Text);
            var captionsRes = string.Join("\n", captions);

            if (captionsRes.Trim() != "text")
            {
                var imageDescMessage = await localizationService.GetTranslateByInterface("app.images.description", userId);

                var text = $"\n{imageDescMessage}\n\n";
                text += "<b>EN</b>\n";
                text += captionsRes;
                resText += text;

                var languagesToTranslate = GetLanguagesToTranslate(settings);
                var resp = await TranslateImageRecognitionResponse(languagesToTranslate, new string[] { captionsRes });

                if (resp.isOnlyOneLanguage)
                {
                    resText += $"\n\n<b>{languagesToTranslate.First().GetCode().ToUpper()}</b>\n";
                    foreach (var sentense in resp.zippedWords.Select(x => x.sNative))
                    {
                        resText += sentense + "\n";
                    }
                }
                else
                {
                    resText += $"\n\n<b>{settings.TargetLanguage!.GetCode().ToUpper()}</b>\n";
                    foreach (var sentense in resp.zippedWords.Select(x => x.fTarget))
                    {
                        resText += sentense + "\n";
                    }

                    resText += $"\n<b>{settings.NativeLanguage!.GetCode().ToUpper()}</b>\n";
                    foreach (var sentense in resp.zippedWords.Select(x => x.sNative))
                    {
                        resText += sentense + "\n";
                    }
                }
            }
        }

        if (!string.IsNullOrEmpty(resText))
        {
            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, resText, parseMode: ParseMode.Html, replyToMessageId: replyId));
        }

        return true;
    }

    private async Task<string> ProccessTagsResponse(IEnumerable<string> en_tags, UserSettings settings)
    {
        if (settings == null)
        {
            logger.LogError("settings null");
            throw new Exception("Settings null");
        }

        var languagesToTranslate = GetLanguagesToTranslate(settings);
        var res = await TranslateImageRecognitionResponse(languagesToTranslate, en_tags.ToArray());

        ConsoleTable onePhrasesTable = null; 
        if (res.isOnlyOneLanguage)
        {
            onePhrasesTable = new ConsoleTable("EN", languagesToTranslate.First().GetCode().ToUpper());
        }
        else
        {
            onePhrasesTable = new ConsoleTable(settings.TargetLanguage!.GetCode().ToUpper(), settings.NativeLanguage!.GetCode().ToUpper());
        }

        var separator = " ";
        var oneWordZipped = res.zippedWords.Where(x => x.fTarget.Split(separator).Length == 1).ToList();
        var phrasesZipped = res.zippedWords.Where(x => x.fTarget.Split(separator).Length > 1).ToList();

        var tableMessage = "";
        if (oneWordZipped != null && oneWordZipped.Count > 0)
        {
            onePhrasesTable.Configure(x => x.EnableCount = false);
            oneWordZipped.ForEach(x => onePhrasesTable.AddRow(x.fTarget, x.sNative));
            tableMessage = "<pre>" + onePhrasesTable.ToMarkDownString() + "</pre>";
        }

        var phrasesMessage = "";
        if(phrasesZipped != null && phrasesZipped.Count > 0)
        {
            phrasesMessage += "\n";
            phrasesZipped.ForEach(x => phrasesMessage += ("<b>" +x.fTarget + "</b>" + " - " + x.sNative + "\n"));
        }

        return tableMessage + phrasesMessage;
    }

    private async Task<(List<(string fTarget, string sNative)> zippedWords, bool isOnlyOneLanguage)> TranslateImageRecognitionResponse(
        List<Language> languagesToTranslate, string[] textToTranslate)
    {
        var codes = languagesToTranslate.Select(x => x.Code);
        var resp = await translateService.TranslateTextsAsync(textToTranslate, codes.ToArray());
        var groupedTranslates = resp.SelectMany(x => x.Translations).GroupBy(x => x.To);
        var l = groupedTranslates.ToList();

        if (groupedTranslates.Count() == 1)
        {
            var otherTranslations = l[0].Select(x => x.Text);
            return (textToTranslate.Zip(otherTranslations).ToList(), true);
        }

        var targetLanguageTranslate = l[0].Select(x => x.Text);
        var nativeLanguageTranslate = l[1].Select(x => x.Text);

        return (targetLanguageTranslate.Zip(nativeLanguageTranslate).ToList(), false);
    }

    private List<Language> GetLanguagesToTranslate(UserSettings settings)
    {
        var languagesToTranslate = new List<Language>();

        if (settings.TargetLanguage!.Code != "en")
        {
            languagesToTranslate.Add(settings.TargetLanguage);
        }
        if (settings.NativeLanguage!.Code != "en")
        {
            languagesToTranslate.Add(settings.NativeLanguage);
        }

        return languagesToTranslate;
    }

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await computerVisionService.OCRImageAsync(bytes);

        if (results == null || !results.IsSuccess || results.TextResults.Count == 0)
        {
            return false;
        }

        var textPhotoMessage = await localizationService.GetTranslateByInterface("app.images.text", userId);
        var text = $"{textPhotoMessage}\n\n";

        var texts = string.Join("\n", results.TextResults.SelectMany(x => x.Lines).Select(x => x.Text));

        if (!string.IsNullOrEmpty(texts))
        {
            text += texts;
            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, text, parseMode: ParseMode.Html, replyToMessageId: replyId));
        }

        return true;
    }
}
