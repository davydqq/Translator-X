using ConsoleTables;
using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TB.BillingPlans;
using TB.Common;
using TB.ComputerVision.Command;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.Entities.Users;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Texts.Commands;
using TB.Translator.Commands;
using TB.Translator.Entities;
using TB.User;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Images.Commands;

public class HandleImagesCommandHandler : ICommandHandler<HandleImagesCommand, bool>
{
    private readonly ILogger<HandleImagesCommandHandler> logger;

    private readonly IQueryDispatcher queryDispatcher;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly IUserService userService;

    private readonly ILocalizationService localizationService;

    private readonly UserSettingsRepository userSettingsRepository;

    private readonly IBillingPlanService billingPlanService;

    private readonly string[] supportedFormats = PhotosExtension.GetFormats();

    private int four_mb = 4194304;

    public HandleImagesCommandHandler(
        ILogger<HandleImagesCommandHandler> logger, 
        IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher,
        IUserService userService,
        ILocalizationService localizationService,
        UserSettingsRepository userSettingsRepository,
        IBillingPlanService billingPlanService)
    {
        this.logger = logger;
        this.queryDispatcher = queryDispatcher;
        this.commandDispatcher = commandDispatcher;
        this.userService = userService;
        this.localizationService = localizationService;
        this.userSettingsRepository = userSettingsRepository;
        this.billingPlanService = billingPlanService;
    }

    public async Task<bool> HandleAsync(HandleImagesCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);
        if (!res) return false;

        var isCanProcessRequest = await billingPlanService.IsCanProcessImageAsync(command.UserId);
        if (!isCanProcessRequest)
        {
            var text = await localizationService.GetTranslateByInterface("billing.exceedLimit", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        var file = command.Files.Where(x => x.Size < four_mb).MaxBy(x => x.Size);
        if(file == null)
        {
            var text = await localizationService.GetTranslateByInterface("app.photo.tooLargeFile", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        // PROCESSING MESSAGE
        var processingMessage = await localizationService.GetTranslateByInterface("app.content.processing", command.UserId);
        var processesingMessageCommand = new SendMessageCommand(command.ChatId, processingMessage, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
        var processingMessageResult = await commandDispatcher.DispatchAsync(processesingMessageCommand);

        var downloadFile = await queryDispatcher.DispatchAsync(new DownloadFileQuery(file.TelegramFileId));

        var extension = Path.GetExtension(downloadFile.Path);
        if (!supportedFormats.Any(x => x == extension))
        {
            var text = await localizationService.GetTranslateByInterface("app.photo.noSupportFormat", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        await ProcessCaptions(command.ChatId, command.UserId, command.MessageId, command.Caption, command.MessageId, command.Update);

        var res1 = await ProcessAndSendOCRResultsAsync(downloadFile.File, command.ChatId, command.UserId, command.MessageId);
        if (!res1)
        {
            await SendErrorMessage(command.ChatId, command.MessageId, command.UserId);
            return false;
        }

        var res2 = await ProcessAndSendPhotoAnalysisAsync(downloadFile.File, command.ChatId, command.UserId, command.MessageId);
        if (!res2)
        {
            await SendErrorMessage(command.ChatId, command.MessageId, command.UserId);
        }

        // DELETE PROCESSING MESSAGE
        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, processingMessageResult.First().MessageId));

        return true;
    }

    private async Task SendErrorMessage(long chatId, int replyId, long userId)
    {
        var errorText = await localizationService.GetTranslateByInterface("app.photo.cantProcess", userId);
        var commandTelegram = new SendMessageCommand(chatId, errorText, parseMode: ParseMode.Html, replyToMessageId: replyId);
        await commandDispatcher.DispatchAsync(commandTelegram);
    }

    private async Task ProcessCaptions(long chatId, long userId, int messageId, string caption, int replyId, Update update)
    {
        if (!string.IsNullOrEmpty(caption))
        {
            var command = new HandleTextsCommand(chatId, userId, messageId, caption, update, replyId);
            await commandDispatcher.DispatchAsync(command);
        }
    }

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await commandDispatcher.DispatchAsync(new AnalyzeImageCommand(bytes, userId));

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

            text += await ProccessTagsResponse(resTags, settings, userId);

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

                var translations = await GetTranslations(settings, new string[] { captionsRes }, userId);
                if (!translations.IsEmpty)
                {
                    if (translations.IsOneLanguage)
                    {
                        resText += $"\n\n<b>{translations.GetOneLanguage.GetCode().ToUpper()}</b>\n";
                        foreach (var sentense in translations.GetOneTranslations.Select(x => x.Translate))
                        {
                            resText += sentense + "\n";
                        }
                    }

                    if (!translations.IsOneLanguage)
                    {
                        resText += $"\n\n<b>{translations.FirstLanguage!.GetCode().ToUpper()}</b>\n";
                        foreach (var sentense in translations.FirstTranslations.Select(x => x.Translate))
                        {
                            resText += sentense + "\n";
                        }

                        resText += $"\n<b>{translations.SecondLanguage!.GetCode().ToUpper()}</b>\n";
                        foreach (var sentense in translations.SecondTranslations.Select(x => x.Translate))
                        {
                            resText += sentense + "\n";
                        }
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

    private async Task<string> ProccessTagsResponse(IEnumerable<string> en_tags, UserSettings settings, long userId)
    {
        if (settings == null)
        {
            logger.LogError("settings null");
            throw new Exception("Settings null");
        }

        var translations = await GetTranslations(settings, en_tags.ToArray(), userId);
        if (!translations.IsEmpty)
        {
            // HEADER
            ConsoleTable onePhrasesTable = null;
            if (translations.IsOneLanguage)
            {
                onePhrasesTable = new ConsoleTable("EN", translations.GetOneLanguage.GetCode().ToUpper());
            }
            else
            {
                onePhrasesTable = new ConsoleTable(translations.FirstLanguage!.GetCode().ToUpper(),
                                                   translations.SecondLanguage!.GetCode().ToUpper());
            }

            var zippedWords = new List<(string first, string second)>();

            // Zip Words
            if (translations.IsOneLanguage)
            {
                zippedWords = en_tags.Zip(translations.GetOneTranslations.Select(x => x.Translate)).ToList();
            }
            else
            {
                var fTranlations = translations.FirstTranslations.Select(x => x.Translate);
                var sTranlations = translations.SecondTranslations.Select(x => x.Translate);
                zippedWords = fTranlations.Zip(sTranlations).ToList();
            }

            //
            var oneWordZipped = new List<(string fTarget, string sNative)>();
            var phrasesZipped = new List<(string fTarget, string sNative)>();

            foreach (var zipWords in zippedWords)
            {
                if (zipWords.first.Length + zipWords.second.Length < 24)
                {
                    oneWordZipped.Add((zipWords.first, zipWords.second));
                    continue;
                }

                phrasesZipped.Add((zipWords.first, zipWords.second));
            }

            var tableMessage = "";
            if (oneWordZipped != null && oneWordZipped.Count > 0)
            {
                onePhrasesTable.Configure(x => x.EnableCount = false);
                oneWordZipped.ForEach(x => onePhrasesTable.AddRow(x.fTarget, x.sNative));
                tableMessage = "<pre>" + onePhrasesTable.ToMarkDownString() + "</pre>";
            }

            var phrasesMessage = "";
            if (phrasesZipped != null && phrasesZipped.Count > 0)
            {
                phrasesMessage += "\n";
                phrasesZipped.ForEach(x => phrasesMessage += ("<b>" + x.fTarget + "</b>" + " - " + x.sNative + "\n"));
            }

            return tableMessage + phrasesMessage;
        }

        return string.Empty;
    }

    private async Task<TranslateTextsDifferentLanguages> GetTranslations(UserSettings settings, string[] textsToTranslate, long userId)
    {
        TranslateTextsDifferentLanguages result = new();

        if (settings.TargetLanguage!.Code != "en")
        {
            result.FirstLanguage = settings.TargetLanguage;

            var command = new TranslateTextsCommand(textsToTranslate.ToList(), settings.TargetLanguage, userId);
            result.FirstTranslations = await commandDispatcher.DispatchAsync(command);
        }
        if (settings.NativeLanguage!.Code != "en")
        {
            result.SecondLanguage = settings.NativeLanguage;

            var command = new TranslateTextsCommand(textsToTranslate.ToList(), settings.NativeLanguage, userId);
            result.SecondTranslations = await commandDispatcher.DispatchAsync(command);
        }

        return result;
    }

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await commandDispatcher.DispatchAsync(new OCRImageCommand(bytes, userId));

        if (results == null || !results.IsSuccess || results.TextResults.Count == 0)
        {
            return false;
        }

        // var textPhotoMessage = await localizationService.GetTranslateByInterface("app.images.text", userId);
        var text = "";

        var texts = string.Join("\n", results.TextResults.SelectMany(x => x.Lines).Select(x => x.Text));

        if (!string.IsNullOrEmpty(texts))
        {
            text += texts;
            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, text, parseMode: ParseMode.Html, replyToMessageId: replyId));
        }

        return true;
    }
}
