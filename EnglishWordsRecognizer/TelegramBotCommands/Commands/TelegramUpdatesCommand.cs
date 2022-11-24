using CQRS.Commands;
using Telegram.Bot.Types;

namespace TB.Routing.Commands;

public class TelegramUpdatesCommand : ICommand<bool>
{
    public Update Update { set; get; }

    public TelegramUpdatesCommand(Update update)
    {
        Update = update;
    }
}
