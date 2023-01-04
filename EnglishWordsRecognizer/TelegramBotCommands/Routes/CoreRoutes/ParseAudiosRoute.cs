using TB.Audios.Commands;
using TB.Common;
using TB.Routing.Entities;
using Telegram.Bot.Types;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseAudiosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        return TelegramMessageContentHelper.IsAudioRoute(update.Message);
    }

    public BaseRouteResult<bool> GetCommand(Update update)
    {
        var message = update.Message;

        var userId = message.From.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var file = TelegramMessageContentHelper.GetAudio(message);

        var command = new HandleAudiosCommand(chatId, userId, messageId, file, update);

        return new BaseRouteResult<bool>(command);
    }
}
