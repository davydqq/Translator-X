using CQRS.Commands;
using Microsoft.Extensions.Logging;

namespace TB.Replies.Commands;

public class HandleRepliesCommandHandler : ICommandHandler<HandleRepliesCommand>
{
    private readonly ILogger<HandleRepliesCommandHandler> logger;

    public HandleRepliesCommandHandler(ILogger<HandleRepliesCommandHandler> logger)
    {
        this.logger = logger;
    }

    public Task HandleAsync(HandleRepliesCommand command, CancellationToken cancellation = default)
    {
        return Task.CompletedTask;
    }
}
