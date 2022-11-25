using CQRS.Commands;

namespace TB.Texts.Commands;

public class HandleTextsCommand : ICommand
{
	public HandleTextsCommand(long chatId, long userId, int messageId, string text, int? replyId = null)
	{
		ChatId = chatId;
		UserId = userId;
		MessageId = messageId;
		Text = text;
		ReplyId = replyId;
	}

	public long ChatId { get; }

	public long UserId { get; }

	public int MessageId { get; }

	public string Text { get; }

	public int? ReplyId { get; }
}
