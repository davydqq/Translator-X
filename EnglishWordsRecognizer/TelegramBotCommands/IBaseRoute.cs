using Telegram.Bot.Types;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands;

public interface IBaseRoute 
{
    public BaseRouteResult Execute(Update update);

    public bool CanHandle(Update update);

    public int Order { get; }
}
