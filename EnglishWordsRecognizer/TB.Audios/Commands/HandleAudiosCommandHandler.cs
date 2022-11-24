using CQRS.Commands;
using Microsoft.Extensions.Logging;

namespace TB.Audios.Commands;

public class HandleAudiosCommandHandler : ICommandHandler<HandleAudiosCommand>
{
    private readonly ILogger<HandleAudiosCommandHandler> logger;

    public HandleAudiosCommandHandler(ILogger<HandleAudiosCommandHandler> logger)
    {
        this.logger = logger;
    }

    public Task HandleAsync(HandleAudiosCommand command, CancellationToken cancellation = default)
    {
        return Task.CompletedTask;
    }
}
