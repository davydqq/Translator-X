using Telegram.Bot.Types;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands;

public interface IBaseCommand 
{
    public BaseCommandResult Execute(Update update);

    public bool CanHandle(Update update);

    public int Order { get; }
}
