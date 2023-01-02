using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TB.Core.Commands;

public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand, bool>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<DeleteMessageCommandHandler> logger;

    public DeleteMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger<DeleteMessageCommandHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<bool> HandleAsync(DeleteMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            await telegramBotClient.DeleteMessageAsync(command.ChatId, command.MessageId);
            return true;
        }
        catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been deleted");
            return false;
        }
    }
}
