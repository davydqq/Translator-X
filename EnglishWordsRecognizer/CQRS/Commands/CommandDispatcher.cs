using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace CQRS.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public Task<TCommandResult> DispatchAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TCommandResult));
        dynamic handler = _serviceProvider.GetRequiredService(handlerType);
        return handler.HandleAsync((dynamic)command, cancellation);
    }

    public Task DispatchAsync(ICommand command, CancellationToken cancellation = default)
    {
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        dynamic handler = _serviceProvider.GetRequiredService(handlerType);
        return handler.HandleAsync((dynamic)command, cancellation);
    }
}
