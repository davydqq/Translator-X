using CQRS.Commands;

namespace TelegramBotCommands.Entities;

public class BaseRouteResult
{
    public ICommand Command { set; get; }

    public BaseRouteResult(ICommand command)
    {
        Command = command;
    }
}
