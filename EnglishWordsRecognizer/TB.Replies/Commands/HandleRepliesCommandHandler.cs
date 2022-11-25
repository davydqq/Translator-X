using CQRS.Commands;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using TB.Texts.Commands;

namespace TB.Replies.Commands;

public class HandleRepliesCommandHandler : ICommandHandler<HandleRepliesCommand>
{
    private readonly ILogger<HandleRepliesCommandHandler> logger;
    private readonly ICommandDispatcher commandDispatcher;

    public HandleRepliesCommandHandler(
        ILogger<HandleRepliesCommandHandler> logger,
        ICommandDispatcher commandDispatcher)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
    }

    public async Task HandleAsync(HandleRepliesCommand command, CancellationToken cancellation = default)
    {
        var commandToSend = new HandleTextsCommand(command.ChatId, command.UserId, command.MessageId, command.ReplyText);
        await commandDispatcher.DispatchAsync(commandToSend);
    }
}
