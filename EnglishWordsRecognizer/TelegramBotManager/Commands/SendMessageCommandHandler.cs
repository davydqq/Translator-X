using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TB.Core.Commands;

public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand, Message>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<SendMessageCommandHandler> logger;

    private readonly AsyncRetryPolicy retryPolicy = Policy.Handle<Exception>()
                        .WaitAndRetryAsync(retryCount: 2, sleepDurationProvider: _ => TimeSpan.FromSeconds(1));

    public SendMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger<SendMessageCommandHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<Message> HandleAsync(SendMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {

            var message = await retryPolicy.ExecuteAsync(() => telegramBotClient.SendTextMessageAsync(
                command.ChatId,
                command.Message,
                parseMode: command.ParseMode,
                replyMarkup: command.ReplyMarkup,
                replyToMessageId: command.ReplyToMessageId
            ));

            return message;
        }
        catch (Exception ex)
        {
            logger.LogWarning($"Message wasn`t been sent: {ex}");
        }

        return null;
    }
}
