using CQRS.Commands;

namespace TB.Routing.Entities;

public class BaseRouteResult<T>
{
    public ICommand<T> Command { set; get; }

    public BaseRouteResult(ICommand<T> command)
    {
        Command = command;
    }
}
