namespace CQRS.Events;

public interface IEventDispatcher
{
    Task DispatchAsync<T>(T @event) where T : class, IEvent;
}
