using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.Core.Commands;
using TB.MemoryStorage;
using TB.Menu.Commands;
using TB.Menu.Entities;
using TB.Translator;

namespace TB.Texts.Commands;

public class HandleTextsCommandHandler : ICommandHandler<HandleTextsCommand>
{
    private readonly ILogger<HandleTextsCommandHandler> logger;

    private readonly Storage memoryStorage;

    private readonly IOptions<BotMenuConfig> menuConfig;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ITranslateService translateService;

    public HandleTextsCommandHandler(
        ILogger<HandleTextsCommandHandler> logger,
        Storage memoryStorage,
        IOptions<BotMenuConfig> menuConfig,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService)
    {
        this.logger = logger;
        this.memoryStorage = memoryStorage;
        this.menuConfig = menuConfig;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
    }

    public async Task HandleAsync(HandleTextsCommand command, CancellationToken cancellation = default)
    {
        var isTargetLangugeSetted = memoryStorage.IsTargetLanguageSetted(command.UserId);
        if (!isTargetLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return;
        }

        var isNativeLangugeSetted = memoryStorage.IsNativeLanguageSetted(command.UserId);
        if (!isNativeLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return;
        }

        var languageToId = memoryStorage.GetUserTargetLanguage(command.UserId);
        var languageTo = SupportedLanguages.languagesDict[languageToId];

        // PROCESSING

        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text empty");
            return;
        }

        var resDetect = await translateService.DetectLanguagesAsync(command.Text);

        if (resDetect.Count > 0 && languageTo.Code == resDetect.First().Language)
        {
            var languageFromId = memoryStorage.GetUserNativeLanguage(command.UserId);
            var languageFrom = SupportedLanguages.languagesDict[languageFromId];

            var resTextFrom = await GetTranslationsAsync(command.Text, languageFrom.Code);

            await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resTextFrom));

            return;
        }

        var resText = await GetTranslationsAsync(command.Text, languageTo.Code);
        await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resText));
    }


    private async Task<string> GetTranslationsAsync(string text, string langCode)
    {
        var res = await translateService.TranslateTextsAsync(new[] { text }, langCode);
        var resText = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        return resText;
    }
}
