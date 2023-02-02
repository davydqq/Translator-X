using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TB.Core.Commands;

public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand, List<Message>>
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

    public async Task<List<Message>> HandleAsync(SendMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            var res = new List<Message>();

            foreach(var chars in command.Message.Chunk(4000))
            {
                var message = await retryPolicy.ExecuteAsync(() => telegramBotClient.SendTextMessageAsync(
                    command.ChatId,
                    new string(chars),
                    parseMode: command.ParseMode,
                    replyMarkup: command.ReplyMarkup,
                    replyToMessageId: command.ReplyToMessageId
                ));

                res.Add(message);
            }

            return res;
        }
        catch (Exception ex)
        {
            logger.LogError($"Message wasn`t been sent: {ex}");
        }

        return null;
    }
}
