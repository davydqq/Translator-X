using Telegram.Bot.Types;

namespace TB.Common;

public class BaseTelegramMessageCommand
{
    public long ChatId { get; }

    public long UserId { get; }

    public int MessageId { get; }

    public Update Update { get; }

    public BaseTelegramMessageCommand(long chatId, long userId, int messageId, Update update)
    {
        UserId = userId;
        ChatId = chatId;
        MessageId = messageId;
        Update = update;
    }
}
