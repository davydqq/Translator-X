using CQRS.Commands;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using TB.Texts.Commands;
using Telegram.Bot.Types.Enums;

namespace TB.Replies.Commands;

public class HandleRepliesCommandHandler : ICommandHandler<HandleRepliesCommand, bool>
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

    public async Task<bool> HandleAsync(HandleRepliesCommand command, CancellationToken cancellation = default)
    {
        switch (command.ReplyMessage.Type)
        {
            case MessageType.Text:
                {
                    break;
                }
        }


        // TODO NO SUPPORT MESSAGE;

        return true;

        // var commandToSend = new HandleTextsCommand(command.ChatId, command.UserId, command.MessageId, command.ReplyText, command.MessageId);
        // await commandDispatcher.DispatchAsync(commandToSend);
    }
}
