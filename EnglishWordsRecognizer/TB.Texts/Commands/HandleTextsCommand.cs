using CQRS.Commands;

namespace TB.Texts.Commands;

public class HandleTextsCommand : ICommand
{
	public HandleTextsCommand(long chatId, long userId, int messageId, string text)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
		Text = text;
	}

	public long ChatId { get; }

	public long UserId { get; }

	public int MessageId { get; }

	public string Text { get; }
}
