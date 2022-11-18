using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands.MenuCommands;


public class ChangeTargetLanguageTextCommandOptions : BaseCommandOptions
{
}


public class ChangeTargetLanguageTextCommand : BaseTextCommand
{
    public const string callBackId = "target_L-";

    public const string message = $"Choose target language";

    public ChangeTargetLanguageTextCommandOptions options;

    public override string Name => CommandsNames.LanguageTarget;

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var res = new TextInternalCommandResult();

        var buttons = GetLanguagesButtons();
        InlineKeyboardMarkup inlineKeyboard = new(buttons);

        var chatId = options?.ChatId ?? update.Message.Chat.Id;

        await service.SendMessageAsync(chatId, message, ParseMode.Html, inlineKeyboard);

        res.IsExecuted = true;
        return res;
    }

    public void AddOptions(ChangeTargetLanguageTextCommandOptions options)
    {
        this.options = options;
    }

    public static IEnumerable<IEnumerable<InlineKeyboardButton>> GetLanguagesButtons()
    {
        return SupportedLanguages.GetLanguages().Chunk(2).Select(languages =>
        {
            return languages.Select(language =>
            {
                var name = language.Name;
                var languageCallbackData = callBackId + language.Id.ToString();

                return InlineKeyboardButton.WithCallbackData(text: language.Name, callbackData: languageCallbackData);
            });
        });
    }
}
