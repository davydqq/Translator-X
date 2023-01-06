using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TB.Core.Commands;

public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand, Message>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<SendMessageCommandHandler> logger;

    public SendMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger<SendMessageCommandHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task<Message> HandleAsync(SendMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            // TODO RETRY
            var message = await telegramBotClient.SendTextMessageAsync(
                command.ChatId, 
                command.Message, 
                parseMode: command.ParseMode,
                replyMarkup: command.ReplyMarkup,
                replyToMessageId: command.ReplyToMessageId
            );

            return message;
        }
        catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been sent: ", e.Message);
        }

        return null;
    }
}
