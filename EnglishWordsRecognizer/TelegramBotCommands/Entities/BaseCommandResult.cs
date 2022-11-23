using CQRS.Commands;

namespace TelegramBotCommands.Entities;

public class BaseCommandResult
{
    public ICommand Command { set; get; }

    public BaseCommandResult(ICommand command)
    {
        Command = command;
    }
}
