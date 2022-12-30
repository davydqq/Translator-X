using ConsoleTables;
using CQRS.Commands;
using CQRS.Queries;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using TB.ComputerVision;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Texts.Commands;
using TB.Translator;
using TB.User;
using Telegram.Bot.Types.Enums;

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
        // TODO add validation accepted types;

        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (res)
        {
            var file = command.Files.MaxBy(x => x.Size);
            var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(file.TelegramFileId));

            await ProcessCaptions(command.ChatId, command.UserId, command.MessageId, command.Caption, command.MessageId);
            await ProcessAndSendOCRResultsAsync(bytes, command.ChatId, command.UserId, command.MessageId);
            await ProcessAndSendPhotoAnalysisAsync(bytes, command.ChatId, command.UserId, command.MessageId);
        }
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

        if (results != null)
        {
            var resText = "";

            var tags = results.Tags?.Select(x => x.Name) ?? new List<string>();
            var descriptionTags = results.Description?.Tags ?? new List<string>();

            var resTags = tags.Union(descriptionTags).Distinct();

            if (resTags != null && resTags.Any())
            {
                var languages = await langRepository.GetWhereAsync(x => x.Id != LanguageENUM.English);
                var languagesToTranslate = languages.Select(x => x.Code).ToArray();

                var imageObjectsMessage = await localizationService.GetTranslateByInterface("app.images.objects", userId);
                var text = $"{imageObjectsMessage}\n\n";

                text += await DrawTableFromTags(resTags, userId);

                resText += text;
            }

            if (results.Description != null)
            {
                var captions = results.Description.Captions.Select(x => x.Text);

                var imageDescMessage = await localizationService.GetTranslateByInterface("app.images.description", userId);

                var text = $"\n{imageDescMessage}\n";
                text += string.Join("\n", captions);
                resText += text;
            }

            if (!string.IsNullOrEmpty(resText))
            {
                await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, resText, parseMode: ParseMode.Html, replyToMessageId: replyId));
            }
        }

        return false;
    }

    private async Task<string> DrawTableFromTags(IEnumerable<string> en_tags, long userId)
    {
        var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(userId);

        if (settings == null)
        {
            logger.LogError("settings null");
            throw new Exception("Settings null");
        }

        var oneLTag = "";
        var languagesToTranslate = new List<string>();

        if (settings.TargetLanguage!.Code != "en")
        {
            languagesToTranslate.Add(settings.TargetLanguage!.Code);
            oneLTag = settings.TargetLanguage!.Code;
        }
        if (settings.NativeLanguage!.Code != "en")
        {
            languagesToTranslate.Add(settings.NativeLanguage!.Code);
            oneLTag = settings.NativeLanguage!.Code;
        }

        var resp = await translateService.TranslateTextsAsync(en_tags.ToArray(), languagesToTranslate.ToArray());

        var groupedTranslates  = resp.SelectMany(x => x.Translations).GroupBy(x => x.To);

        string markdown = null;

        if (groupedTranslates.Count() == 1)
        {
            var l = groupedTranslates.ToList();
            var otherTags = l[0].Select(x => x.Text);

            var zippedWords = en_tags.Zip(otherTags).ToList();

            var table = new ConsoleTable("EN", oneLTag.ToUpper());
            table.Configure(x => x.EnableCount = false);
            zippedWords.ForEach(x => table.AddRow(x.First, x.Second));

            markdown = table.ToMarkDownString();
        }
        if (groupedTranslates.Count() == 2)
        {
            var l = groupedTranslates.ToList();
            var targetTags = l[0].Select(x => x.Text);
            var nativeTags = l[1].Select(x => x.Text);

            var zippedWords = en_tags.Zip(targetTags, nativeTags).ToList();

            var table = new ConsoleTable("EN", settings.TargetLanguage!.Code.ToUpper(), settings.NativeLanguage!.Code.ToUpper());
            table.Configure(x => x.EnableCount = false);
            zippedWords.ForEach(x => table.AddRow(x.First, x.Second, x.Third));

            markdown = table.ToMarkDownString();
        }

        return "<pre>" + markdown + "</pre>";
    }

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await computerVisionService.OCRImageAsync(bytes);

        if (results != null && results.TextResults.Count > 0)
        {
            var textPhotoMessage = await localizationService.GetTranslateByInterface("app.images.text", userId);

            var text = $"{textPhotoMessage}\n\n";
            var texts = string.Join("\n", results.TextResults.SelectMany(x => x.Lines).Select(x => x.Text));

            if (!string.IsNullOrEmpty(texts))
            {
                text += texts;
                await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, text, parseMode: ParseMode.Html, replyToMessageId: replyId));

                return true;
            }
        }

        return false;
    }
}
