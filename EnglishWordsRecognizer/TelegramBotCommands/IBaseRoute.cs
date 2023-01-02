using TB.Routing.Entities;
using Telegram.Bot.Types;

namespace TB.Routing;

public interface IBaseRoute
{
    public BaseRouteResult<bool> GetCommand(Update update);

    public bool CanHandle(Update update);

    public int Order { get; }
}
