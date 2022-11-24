using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.ComputerVision;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.MemoryStorage;
using TB.MemoryStorage.Languages;
using TB.Menu.Commands;
using TB.Menu.Entities;
using TB.Translator;
using TelegramBotStorage;

namespace TB.Images.Commands;

public class HandleImagesCommandHandler : ICommandHandler<HandleImagesCommand>
{
    private readonly ILogger<HandleImagesCommandHandler> logger;

    private readonly IComputerVisionService computerVisionService;

    private readonly IQueryDispatcher queryDispatcher;

    private readonly Storage memoryStorage;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly IOptions<BotMenuConfig> menuConfig;

    private readonly ITranslateService translateService;

    public HandleImagesCommandHandler(
        ILogger<HandleImagesCommandHandler> logger, 
        IComputerVisionService computerVisionService,
        IQueryDispatcher queryDispatcher,
        Storage memoryStorage,
        ICommandDispatcher commandDispatcher,
        IOptions<BotMenuConfig> menuConfig,
        ITranslateService translateService)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.queryDispatcher = queryDispatcher;
        this.memoryStorage = memoryStorage;
        this.commandDispatcher = commandDispatcher;
        this.menuConfig = menuConfig;
        this.translateService = translateService;
    }

    public async Task HandleAsync(HandleImagesCommand command, CancellationToken cancellation = default)
    {
        // TODO add validation accepted types;

        var res = await ValidateThatUserSelectLanguages(command);

        if (res)
        {
            var file = command.Files.MaxBy(x => x.Size);
            var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(file.TelegramFileId));

            await ProcessAndSendOCRResultsAsync(bytes, command.ChatId, command.UserId);
            await ProcessAndSendPhotoAnalysisAsync(bytes, command.ChatId, command.UserId);
        }
    }

    private async Task<bool> ValidateThatUserSelectLanguages(HandleImagesCommand command)
    {
        var isTargetLangugeSetted = memoryStorage.IsTargetLanguageSetted(command.UserId);
        if (!isTargetLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        var isNativeLangugeSetted = memoryStorage.IsNativeLanguageSetted(command.UserId);
        if (!isNativeLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        return true;
    }

    private async Task<bool> ProcessAndSendPhotoAnalysisAsync(byte[] bytes, long chatId, long userId)
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
                var languagesToTranslate = memoryStorage.GetUserLanguages(userId)
                                                   .Where(x => x.Id != LanguageENUM.English)
                                                   .Select(x => x.Code).ToArray();
                // TODO output for diff languages
                var resp = await translateService.TranslateTextsAsync(resTags.ToArray(), languagesToTranslate);

                var text = "Photo objects\n\n";
                text += string.Join("\n", resTags);

                resText += text;
            }

            if (results.Description != null)
            {
                var captions = results.Description.Captions.Select(x => x.Text);

                var text = "\nPhoto description\n\n";
                text += string.Join("\n", captions);
                resText += text;
            }

            if (!string.IsNullOrEmpty(resText))
            {
                await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, resText));
            }
        }

        return false;
    }

    private async Task<bool> ProcessAndSendOCRResultsAsync(byte[] bytes, long chatId, long userId)
    {
        var results = await computerVisionService.OCRImageAsync(bytes);

        if (results != null && results.TextResults.Count > 0)
        {
            var text = "Text on photo\n\n";
            var texts = string.Join("\n", results.TextResults.SelectMany(x => x.Lines).Select(x => x.Text));

            if (!string.IsNullOrEmpty(texts))
            {
                text += texts;
                await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, text));

                return true;
            }
        }

        return false;
    }
}
