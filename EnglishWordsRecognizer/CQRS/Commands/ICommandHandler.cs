namespace CQRS.Commands;

public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : class, ICommand<TCommandResult>
{
    Task<TCommandResult> HandleAsync(TCommand command, CancellationToken cancellation = default);
}

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellation = default);
}
