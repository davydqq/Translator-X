using TB.Replies.Commands;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseRepliesRoute : IBaseRoute
{
    public int Order => 2;


    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Text && message.ReplyToMessage != null;
    }

    public BaseRouteResult<bool> GetCommand(Update update)
    {
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var originalText = message.Text;

        var command = new HandleRepliesCommand(userId, chatId, messageId, message.ReplyToMessage, originalText);
        return new BaseRouteResult<bool>(command);
    }
}
