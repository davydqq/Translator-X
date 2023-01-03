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

public class HandleTextsCommandHandler : ICommandHandler<HandleTextsCommand, bool>
{
    private readonly ILogger<HandleTextsCommandHandler> logger;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ITranslateService translateService;

    private readonly IUserService userService;

    private readonly CambridgeDictionaryService cambridgeDictionaryService;
    private readonly ThesaurusService thesaurusService;
    private readonly UserSettingsRepository repositoryUserSettings;

    private readonly ILocalizationService localizationService;

    public HandleTextsCommandHandler(
        ILogger<HandleTextsCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        ITranslateService translateService,
        IUserService userService,
        CambridgeDictionaryService cambridgeDictionaryService,
        ThesaurusService thesaurusService,
        UserSettingsRepository repositoryUserSettings,
        ILocalizationService localizationService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.translateService = translateService;
        this.userService = userService;
        this.cambridgeDictionaryService = cambridgeDictionaryService;
        this.thesaurusService = thesaurusService;
        this.repositoryUserSettings = repositoryUserSettings;
        this.localizationService = localizationService;
    }

    public async Task<bool> HandleAsync(HandleTextsCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (!res) return false;

        var userSettings = await repositoryUserSettings.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);
        var languageTo = userSettings.TargetLanguage;
        // PROCESSING

        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text empty");
            return false;
        }

        if (command.Text.Length > 40000)
        {
            var text = await localizationService.GetTranslateByInterface("app.text.maxLength", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        var resDetect = await translateService.DetectLanguagesAsync(command.Text);

        if (resDetect.Count > 0 && languageTo.Code == resDetect.First().Language)
        {
            var languageFrom = userSettings.NativeLanguage;

            var resTextFrom = await GetTranslationsAsync(command.Text, languageFrom.Code);

            var sentMessage = await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resTextFrom, replyToMessageId: command.ReplyId));

            await HandleMeaning(languageTo, command.Text, command.UserId, command.ChatId, command.MessageId, command.MessageId);

            return true;
        }

        var resText = await GetTranslationsAsync(command.Text, languageTo.Code);
        var message = await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resText, replyToMessageId: command.ReplyId));

        await HandleMeaning(languageTo, resText, command.UserId, command.ChatId, message.MessageId, message.MessageId);

        return true;
    }

    private async Task HandleMeaning(Language language, string text, long userId, long chatId, int? replyId, int? replySynonymId)
    {
        if (text.Length > 50) return;
        // todo add reverse lofic
        switch (language.Id)
        {
            case LanguageENUM.English:
                {
                    var meaningActive = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == userId && x.RecognizeEnglishMeaning);
                    if (meaningActive)
                    {
                        // meaning
                        var result = await cambridgeDictionaryService.GetCambridgeEnglishAsync(text);
                        var message = await GetMessageMeaning(result, userId);
                        if (!string.IsNullOrEmpty(message))
                        {
                            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, message, replyToMessageId: replyId, parseMode: ParseMode.Html));
                        }
                        // synonyms
                        var synonyms = await thesaurusService.GetSynonymsAsync(text);
                        if(synonyms != null && synonyms.Count() > 0)
                        {
                            var synonumKey = "<b>Synonym</b>\n\n";
                            synonyms = synonyms.Take(10);
                            var messageText = synonumKey + string.Join(", ", synonyms);
                            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, messageText, replyToMessageId: replySynonymId, parseMode: ParseMode.Html));
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

        message += $"{maybeMeanMessage}\n\n";

        foreach (var item in result.Results)
        {
            message += "• " + "<b>" + item.Phrase + "</b>" + " - " + item.Meaning;
            message += "\n\n";
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
