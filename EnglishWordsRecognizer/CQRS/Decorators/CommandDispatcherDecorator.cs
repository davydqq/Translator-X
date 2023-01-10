using CQRS.Commands;
using CQRS.Queries;

namespace CQRS.Decorators;

public class CommandDispatcherDecorator : ICommandDispatcher
{
    private readonly ICommandDispatcher commandDispatcher;

    public CommandDispatcherDecorator(ICommandDispatcher dispatcher)
    {
        this.commandDispatcher = dispatcher;
    }

    public async Task<TCommandResult> DispatchAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default)
    {
        // Before operation stuff
        var result = await commandDispatcher.DispatchAsync(command, cancellation);
        // After operation stuff
        return result;
    }
}
