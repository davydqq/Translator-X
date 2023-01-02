using TB.Routing.Entities;
using Telegram.Bot.Types;

namespace TB.Routing.Routes
{
    public class OtherRoute : IBaseRoute
    {
        public int Order => int.MaxValue;

        public bool CanHandle(Update update)
        {
            return true;
        }

        public BaseRouteResult<bool> GetCommand(Update update)
        {
            return new BaseRouteResult<bool>(null);
        }
    }
}
