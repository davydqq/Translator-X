using CQRS.Commands;
using Microsoft.Extensions.Logging;

namespace TB.Documents.Commands;

public class HandleDocumentsCommandHandler : ICommandHandler<HandleDocumentsCommand>
{
    private readonly ILogger<HandleDocumentsCommandHandler> logger;

    public HandleDocumentsCommandHandler(ILogger<HandleDocumentsCommandHandler> logger)
    {
        this.logger = logger;
    }

    public Task HandleAsync(HandleDocumentsCommand command, CancellationToken cancellation = default)
    {
        return Task.CompletedTask;
    }
}
