using TB.Routing;
using TB.Routing.Entities;
using TB.Texts.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

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

    public BaseRouteResult<bool> GetCommand(Update update)
    {
        var message = update.Message;

        var userId = message.From.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;
        var text = message.Text;

        var command = new HandleTextsCommand(chatId, userId, messageId, text, messageId);
        return new BaseRouteResult<bool>(command);
    }
}
