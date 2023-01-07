using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Polly.Retry;
using Polly;
using Telegram.Bot;

namespace TB.Core.Commands;

public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand, bool>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<DeleteMessageCommandHandler> logger;

    private readonly AsyncRetryPolicy retryPolicy = Policy.Handle<Exception>()
                    .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: _ => TimeSpan.FromSeconds(1));

    public DeleteMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger<DeleteMessageCommandHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<bool> HandleAsync(DeleteMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            await retryPolicy.ExecuteAsync(() => telegramBotClient.DeleteMessageAsync(command.ChatId, command.MessageId));
            return true;
        }
        catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been deleted");
            return false;
        }
    }
}
