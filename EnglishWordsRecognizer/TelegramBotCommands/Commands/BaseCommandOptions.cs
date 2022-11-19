namespace TelegramBotCommands.Commands;

public class BaseCommandOptions
{
    public long ChatId { set; get; }

    public int MessageId { set; get; }

    public bool IsDeleteCurrentMessage { set; get; }
}