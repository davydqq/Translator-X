namespace CQRS.Events;

public interface IEventHandler<TEvent> where TEvent : class, IEvent
{
    Task HandleAsync(IEvent @event);
}
