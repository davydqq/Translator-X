using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Core.Commands;
using TB.MemoryStorage;
using TB.Translator;
using TB.User;

namespace TB.Texts.Commands;

public class HandleTextsCommandHandler : ICommandHandler<HandleTextsCommand>
{
    private readonly ILogger<HandleTextsCommandHandler> logger;

    private readonly Storage memoryStorage;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ITranslateService translateService;

    private readonly IUserService userService;

    public HandleTextsCommandHandler(
        ILogger<HandleTextsCommandHandler> logger,
        Storage memoryStorage,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService,
        IUserService userService)
    {
        this.logger = logger;
        this.memoryStorage = memoryStorage;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
        this.userService = userService;
    }

    public async Task HandleAsync(HandleTextsCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (res)
        {
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

                await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resTextFrom, replyToMessageId: command.ReplyId));

                return;
            }

            var resText = await GetTranslationsAsync(command.Text, languageTo.Code);
            await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resText, replyToMessageId: command.ReplyId));
        }
    }


    private async Task<string> GetTranslationsAsync(string text, string langCode)
    {
        var res = await translateService.TranslateTextsAsync(new[] { text }, langCode);
        var resText = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        return resText;
    }
}
