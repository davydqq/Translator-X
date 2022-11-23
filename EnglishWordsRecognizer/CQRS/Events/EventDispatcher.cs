using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Events;

public class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task DispatchAsync(IEvent @event)
    {
        var handlers = _serviceProvider.GetServices<IEventHandler<IEvent>>();
        foreach(var handler in handlers)
        {
            await handler.HandleAsync(@event);
        }
    }
}
