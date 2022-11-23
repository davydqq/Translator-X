namespace CQRS.Commands;

public interface ICommand
{
}

public interface ICommand<TResponse> : ICommand
{
}
