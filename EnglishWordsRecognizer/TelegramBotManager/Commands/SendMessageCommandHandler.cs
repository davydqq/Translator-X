using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace TB.Core.Commands;

public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
{
    private readonly TelegramBotClient telegramBotClient;
    private readonly ILogger<SendMessageCommandHandler> logger;

    public SendMessageCommandHandler(TelegramBotClient telegramBotClient, ILogger<SendMessageCommandHandler> logger)
    {
        this.telegramBotClient = telegramBotClient;
        this.logger = logger;
    }

    public async Task HandleAsync(SendMessageCommand command, CancellationToken cancellation = default)
    {
        try
        {
            await telegramBotClient.SendTextMessageAsync(
                command.ChatId, 
                command.Message, 
                parseMode: command.ParseMode,
                replyMarkup: command.ReplyMarkup,
                replyToMessageId: command.ReplyToMessageId
            );
        }
        catch (Exception e)
        {
            logger.LogWarning("Message wasn`t been sent: ", e.Message);
        }
    }
}
