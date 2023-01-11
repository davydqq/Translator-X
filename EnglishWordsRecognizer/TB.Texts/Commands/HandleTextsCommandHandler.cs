using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.BillingPlans;
using TB.Core.Commands;
using TB.Database.Entities;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.Meaning;
using TB.Meaning.Commands;
using TB.Meaning.Entities;
using TB.Translator.Commands;
using TB.User;
using Telegram.Bot.Types.Enums;

namespace TB.Texts.Commands;

public class HandleTextsCommandHandler : ICommandHandler<HandleTextsCommand, bool>
{
    private readonly ILogger<HandleTextsCommandHandler> logger;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly IUserService userService;

    private readonly UserSettingsRepository repositoryUserSettings;

    private readonly ILocalizationService localizationService;

    private readonly IBillingPlanService billingPlanService;

    public HandleTextsCommandHandler(
        ILogger<HandleTextsCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        IUserService userService,
        UserSettingsRepository repositoryUserSettings,
        ILocalizationService localizationService,
        IBillingPlanService billingPlanService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.userService = userService;
        this.repositoryUserSettings = repositoryUserSettings;
        this.localizationService = localizationService;
        this.billingPlanService = billingPlanService;
    }

    public async Task<bool> HandleAsync(HandleTextsCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);

        if (!res) return false;

        var isCanProcessRequest = await billingPlanService.IsCanProcessTextAsync(command.UserId);
        if (!isCanProcessRequest)
        {
            // TODO MESSAGE
            return false;
        }

        var userSettings = await repositoryUserSettings.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);
        var languageTo = userSettings.TargetLanguage;

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

        var detectLCommand = new DetectLanguagesCommand(command.Text, command.UserId);

        var resDetect = await commandDispatcher.DispatchAsync(detectLCommand);

        if(resDetect == null)
        {
            return false;
        }

        if (resDetect.Count > 0 && languageTo.Code == resDetect.First().Language)
        {
            var languageFrom = userSettings.NativeLanguage;

            var resTextFrom = await GetTranslationsAsync(command.Text, languageFrom.Code, command.UserId);
            if (string.IsNullOrEmpty(resTextFrom)) return false;

            var sentMessage = await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resTextFrom, replyToMessageId: command.ReplyId));

            await HandleMeaning(languageTo, command.Text, command.UserId, command.ChatId, command.MessageId, command.MessageId);

            return true;
        }

        var resText = await GetTranslationsAsync(command.Text, languageTo.Code, command.UserId);
        if (string.IsNullOrEmpty(resText)) return false;
        
        var message = await commandDispatcher.DispatchAsync(new SendMessageCommand(command.ChatId, resText, replyToMessageId: command.ReplyId));
        await HandleMeaning(languageTo, resText, command.UserId, command.ChatId, message.MessageId, message.MessageId);

        return true;      
    }

    private async Task HandleMeaning(Language language, string text, long userId, long chatId, int? replyId, int? replySynonymId)
    {
        if (text.Length > 50) return;
        switch (language.Id)
        {
            case LanguageENUM.English:
                {
                    var meaningActive = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == userId && x.RecognizeEnglishMeaning);
                    if (meaningActive)
                    {
                        // meaning
                        var result = await commandDispatcher.DispatchAsync(new GetPhraseMeaningCommand(text, userId));
                        var message = await GetMessageMeaning(result, userId);
                        if (!string.IsNullOrEmpty(message))
                        {
                            await commandDispatcher.DispatchAsync(new SendMessageCommand(chatId, message, replyToMessageId: replyId, parseMode: ParseMode.Html));
                        }
                        // synonyms
                        var synonyms = await commandDispatcher.DispatchAsync(new GetSynonymsCommand(text, userId));
                        if (synonyms != null && synonyms.Count() > 0)
                        {
                            var synonumKey = "<b>Synonyms</b>\n\n";
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

    private async Task<string> GetTranslationsAsync(string text, string langCode, long userId)
    {
        var textsToTranslate = new List<string> { text };
        var languagesToTranslate = new List<string> { langCode };

        var command = new TranslateTextsCommand(textsToTranslate, languagesToTranslate, userId);
  
        var res = await commandDispatcher.DispatchAsync(command);

        if (res == null) return null;

        var resText = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        return resText;
    }
}
