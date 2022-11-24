using CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotCommands;

namespace TB.Routing;

public static class Modules
{
    public static void RoutingModules(this IServiceCollection services)
    {
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IBaseRoute));
                    })
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
        });
    }
}
