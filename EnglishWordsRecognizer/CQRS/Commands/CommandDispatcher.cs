using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Task<TCommandResult> DispatchAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand<TCommandResult>, TCommandResult>>();
        return handler.HandleAsync(command, cancellation);
    }

    public Task DispatchAsync(ICommand command, CancellationToken cancellation = default)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand>>();
        return handler.HandleAsync(command, cancellation);
    }
}
