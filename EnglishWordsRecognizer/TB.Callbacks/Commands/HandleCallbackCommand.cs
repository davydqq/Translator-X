using CQRS.Commands;

namespace TB.Callbacks.Commands;

public class HandleCallbackCommand : ICommand<bool>
{
	public HandleCallbackCommand(long chatId, long userId, int messageId, string data)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
		Data = data;
	}

	public long ChatId { get; }

	public long UserId { get; }

	public int MessageId { get; }

	public string Data { get; }
}
