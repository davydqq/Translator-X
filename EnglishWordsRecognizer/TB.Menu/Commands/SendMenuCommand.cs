using CQRS.Commands;

namespace TB.Menu.Commands;

public class SendMenuCommand : ICommand
{

	public SendMenuCommand(BotMenuId botMenuId, long chatId, int messageId, long userId, bool deleteMessage)
	{
		BotMenuId = botMenuId;
		ChatId = chatId;
		MessageId = messageId;
		UserId = userId;
		DeleteMessage = deleteMessage;
	}

	public BotMenuId BotMenuId { get; }

	public long ChatId { get; }

	public int MessageId { get; }

	public long UserId { get; }

	public bool DeleteMessage { get; }
}
