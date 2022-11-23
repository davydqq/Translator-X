namespace CQRS.Events;

public interface IEventDispatcher
{
    Task DispatchAsync(IEvent @event);
}
