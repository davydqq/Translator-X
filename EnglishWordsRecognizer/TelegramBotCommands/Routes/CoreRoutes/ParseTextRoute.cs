using TB.Texts.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseTextRoute : IBaseRoute
{
    public int Order => 3;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Text;
    }

    public BaseRouteResult Execute(Update update)
    {
        var message = update.Message;

        var userId = message.From.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;
        var text = message.Text;

        var command = new HandleTextsCommand(chatId, userId, messageId, text);
        return new BaseRouteResult(command);
    }
}
