using CQRS.Commands;

namespace TB.Routing.Entities;

public class BaseRouteResult
{
    public ICommand Command { set; get; }

    public BaseRouteResult(ICommand command)
    {
        Command = command;
    }
}
