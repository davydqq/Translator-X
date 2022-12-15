using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.ComputerVision;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.GenericRepositories;
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

    public HandleImagesCommandHandler(
        ILogger<HandleImagesCommandHandler> logger, 
        IComputerVisionService computerVisionService,
        IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService,
        IUserService userService,
        IRepository<Language, LanguageENUM> langRepository)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.queryDispatcher = queryDispatcher;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
        this.userService = userService;
        this.langRepository = langRepository;
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

                // TODO output for diff languages
                var resp = await translateService.TranslateTextsAsync(resTags.ToArray(), languagesToTranslate);

                var text = "<b>Photo objects</b>\n\n";
                text += string.Join("\n", resTags);

                resText += text;
            }

            if (results.Description != null)
            {
                var captions = results.Description.Captions.Select(x => x.Text);

                var text = "\n<b>Photo description</b>\n";
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

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId, int replyId)
    {
        var results = await computerVisionService.OCRImageAsync(bytes);

        if (results != null && results.TextResults.Count > 0)
        {
            var text = "<b>Text on photo</b>\n\n";
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
