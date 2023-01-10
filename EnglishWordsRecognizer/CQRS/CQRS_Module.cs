using CQRS.Commands;
using CQRS.Decorators;
using CQRS.Events;
using CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CQRS;

public static class CQRS_Module
{
    public static void RegisterCQRS(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>()
                 .Decorate<ICommandDispatcher, CommandDispatcherDecorator>();

        services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.TryAddSingleton<IEventDispatcher, EventDispatcher>();

        services.Scan(selector =>
        {
            selector.FromApplicationDependencies()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
        });
         
        services.Scan(selector =>
        {
            selector.FromApplicationDependencies()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
        });

        services.Scan(selector =>
        {
            selector.FromApplicationDependencies()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IEventHandler<>));
                    })
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
        });
    }
}
