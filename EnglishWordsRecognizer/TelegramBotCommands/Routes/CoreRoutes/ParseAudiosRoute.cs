using TB.Audios.Commands;
using TB.Routing;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseAudiosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Audio || message.Type == MessageType.Voice;
    }

    public BaseRouteResult GetCommand(Update update)
    {
        var command = new HandleAudiosCommand();
        return new BaseRouteResult(command);
    }
}
