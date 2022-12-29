using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Core.Commands;
using TB.Database.Entities;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Meaning;
using TB.Meaning.Entities;
using TB.Translator;
using TB.User;
using Telegram.Bot.Types.Enums;

namespace TB.Texts.Commands;

public class HandleTextsCommandHandler : ICommandHandler<HandleTextsCommand>
{
    private readonly ILogger<HandleTextsCommandHandler> logger;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ITranslateService translateService;

    private readonly IUserService userService;

    private readonly CambridgeDictionaryService cambridgeDictionaryService;

    private readonly UserSettingsRepository repositoryUserSettings;

    private readonly ILocalizationService localizationService;

    public HandleTextsCommandHandler(
        ILogger<HandleTextsCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService,
        IUserService userService,
        CambridgeDictionaryService cambridgeDictionaryService,
        UserSettingsRepository repositoryUserSettings,
        ILocalizationService localizationService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
        this.userService = userService;
        this.cambridgeDictionaryService = cambridgeDictionaryService;
        this.repositoryUserSettings = repositoryUserSettings;
        this.localizationService = localizationService;
    }

    public async Task HandleAsync(HandleTextsCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (res)
        {

            var userSettingsT = await repositoryUserSettings.GetSettingsIncludedLanguageTargetAsync(command.UserId);
            var languageTo = userSettingsT.TargetLanguage;
            // PROCESSING

            if (string.IsNullOrEmpty(command.Text))
            {
                logger.LogError("Text empty");
                return;
            }

            var resDetect = await translateService.DetectLanguagesAsync(command.Text);

            if (resDetect.Count > 0 && languageTo.Code == resDetect.First().Language)
            {
                var userSettingsN = await repositoryUserSettings.GetSettingsIncludeLanguageNativeAsync(command.UserId);
                var languageFrom = userSettingsN.NativeLanguage;

                var resTextFrom = await GetTranslationsAsync(command.Text, languageFrom.Code);

                var sentMessage = await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resTextFrom, replyToMessageId: command.ReplyId));

                await HandleMeaning(languageTo, command.Text, command.UserId, command.ChatId, sentMessage.MessageId);

                return;
            }

            var resText = await GetTranslationsAsync(command.Text, languageTo.Code);
            await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resText, replyToMessageId: command.ReplyId));
            
            await HandleMeaning(languageTo, resText, command.UserId, command.ChatId, command.MessageId);
        }
    }

    private async Task HandleMeaning(Language language, string text, long userId, long chatId, int? replyId)
    {
        // todo add reverse lofic
        switch (language.Id)
        {
            case LanguageENUM.English:
                {
                    var meaningActive = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == userId && x.RecognizeEnglishMeaning);
                    if (meaningActive)
                    {
                        var result = await cambridgeDictionaryService.GetCambridgeEnglishAsync(text);
                        var message = await GetMessageMeaning(result, userId);
                        if (!string.IsNullOrEmpty(message))
                        {
                            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, message, replyToMessageId: replyId, parseMode: ParseMode.Html));
                        }
                    }
                    break;
                }
        }
    }

    private async Task<string> GetMessageMeaning(MeaningResult result, long userId)
    {
        if (result.Results == null || !result.Results.Any())
        {
            return null;
        }

        string message = "";

        if (result.IsMatched)
        {
            foreach (var item in result.Results)
            {
                message += item.Phrase + " - " + item.Meaning;
                message += "\n";
            }

            return message;
        }

        var maybeMeanMessage = await localizationService.GetTranslateByInterface("app.texts.maybeMean", userId);

        message += $"{maybeMeanMessage}\n";

        foreach (var item in result.Results)
        {
            message += "• " + item.Phrase + " - " + item.Meaning;
            message += "\n";
        }

        return message;
    }

    private async Task<string> GetTranslationsAsync(string text, string langCode)
    {
        var res = await translateService.TranslateTextsAsync(new[] { text }, langCode);
        var resText = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        return resText;
    }
}
