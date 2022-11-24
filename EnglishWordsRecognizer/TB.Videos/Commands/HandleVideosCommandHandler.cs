using CQRS.Commands;
using Microsoft.Extensions.Logging;

namespace TB.Videos.Commands;

public class HandleVideosCommandHandler : ICommandHandler<HandleVideosCommand>
{
    private readonly ILogger<HandleVideosCommandHandler> logger;

    public HandleVideosCommandHandler(ILogger<HandleVideosCommandHandler> logger)
    {
        this.logger = logger;
    }

    public Task HandleAsync(HandleVideosCommand command, CancellationToken cancellation = default)
    {
        return Task.CompletedTask;
    }
}
