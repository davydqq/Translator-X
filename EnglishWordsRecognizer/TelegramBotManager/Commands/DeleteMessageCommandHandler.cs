using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TB.Core.Commands;

public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger logger;

    public DeleteMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task HandleAsync(DeleteMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            await telegramBotClient.DeleteMessageAsync(command.ChatId, command.MessageId);
        }
        catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been deleted");
        }
    }
}
