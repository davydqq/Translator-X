using TB.Routing;
using TB.Routing.Entities;
using TB.Videos.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseVideosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Video;
    }

    public BaseRouteResult GetCommand(Update update)
    {
        return new BaseRouteResult(new HandleVideosCommand());
    }
}
