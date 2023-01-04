using CQRS.Commands;
using Telegram.Bot.Types;

namespace TB.Callbacks.Commands;

public class HandleCallbackCommand : ICommand<bool>
{
	public HandleCallbackCommand(long chatId, long userId, int messageId, string data, Update update)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
		Data = data;
		Update = update;
	}

	public long ChatId { get; }

	public long UserId { get; }

	public int MessageId { get; }

	public string Data { get; }

	public Update Update { get; }
}
