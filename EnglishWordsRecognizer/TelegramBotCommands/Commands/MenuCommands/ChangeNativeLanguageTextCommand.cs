using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage;

namespace TelegramBotCommands.Commands.MenuCommands;

public class ChangeNativeLanguageTextCommandOptions : BaseCommandOptions
{

}

public class ChangeNativeLanguageTextCommand : BaseTextCommand
{
    public const string callBackId = "native_L-";

    public override string Name => CommandsNames.LanguageNative;

    public override int Order => 2;

    public ChangeNativeLanguageTextCommandOptions options;

    const string message = $"Choose your native language";

    public ChangeNativeLanguageTextCommand(ChangeNativeLanguageTextCommandOptions options)
    {
        this.options = options;
    }

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var res = new TextInternalCommandResult();

        var chatId = options?.ChatId ?? update.Message.Chat.Id;
        var messageId = options?.MessageId ?? update.Message.MessageId;

        if (options.IsDeleteCurrentMessage)
        {
            await service.DeleteMessageAsync(chatId, messageId);
        }

        var buttons = GetLanguagesButtons();

        InlineKeyboardMarkup inlineKeyboard = new(buttons);
        await service.SendMessageAsync(chatId, message, ParseMode.Html, inlineKeyboard);

        res.IsExecuted = true;
        return res;
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
