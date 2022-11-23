using Telegram.Bot.Types;
using TelegramBotCommands;
using TelegramBotCommands.Entities;

namespace TelegramBotManager;

public abstract class BaseCommand : IBaseCommand
{
    public abstract BaseCommandResult Execute(Update update);

    public abstract bool CanHandle(Update update);

    public abstract int Order { get; }
}
