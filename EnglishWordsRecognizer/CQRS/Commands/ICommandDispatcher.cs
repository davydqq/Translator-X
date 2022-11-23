namespace CQRS.Commands;

interface ICommandDispatcher
{
    Task<TCommandResult> DispatchAsync<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default);

    Task DispatchAsync(ICommand command, CancellationToken cancellation = default);
}