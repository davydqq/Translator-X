using CQRS.Commands;
using TelegramBotCommands;

namespace TB.Routing.Commands;

public class TelegramUpdatesHandler : ICommandHandler<TelegramUpdatesCommand, bool>
{
    private readonly IBaseRoute[] baseRoutes;
    private readonly ICommandDispatcher commandDispatcher;

    public TelegramUpdatesHandler(IBaseRoute[] baseRoutes, ICommandDispatcher commandDispatcher)
    {
        this.baseRoutes = baseRoutes;
        this.commandDispatcher = commandDispatcher;
    }

    public async Task<bool> HandleAsync(TelegramUpdatesCommand command, CancellationToken cancellation = default)
    {
        foreach (var route in baseRoutes)
        {
            if (route.CanHandle(command.Update))
            {
                var res = route.Execute(command.Update);
                if(res != null && res.Command != null)
                {
                    await commandDispatcher.DispatchAsync(res.Command);
                }
            }
        }

        return false;
    }
}
