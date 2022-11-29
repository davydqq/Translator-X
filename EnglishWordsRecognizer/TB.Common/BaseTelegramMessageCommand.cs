namespace TB.Common;

public class BaseTelegramMessageCommand
{
    public long ChatId { get; }

    public long UserId { get; }

    public int MessageId { get; }

    public BaseTelegramMessageCommand(long chatId, long userId, int messageId)
    {
        UserId = userId;
        ChatId = chatId;
        MessageId = messageId;
    }
}
