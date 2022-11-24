using CQRS.Commands;

namespace TB.Menu.Commands;

public class HandleMenuCommand : ICommand
{
	public HandleMenuCommand(BotMenuCommand command, long chatId, int messageId, long userId, bool deleteMessage)
	{
        MenuCommand = command;
		ChatId = chatId;
		MessageId = messageId;
		UserId = userId;
		DeleteMessage = deleteMessage;
	}

	public BotMenuCommand MenuCommand { get; }

	public long ChatId { get; }

	public int MessageId { get; }

	public long UserId { get; }

	public bool DeleteMessage { get; }
}
