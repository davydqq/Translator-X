using CQRS.Commands;

namespace TB.Replies.Commands;

public class HandleRepliesCommand : ICommand
{
	public HandleRepliesCommand(long userId, long chatId, int messageId, string originalText, string replyText)
	{
		UserId = userId;
		ChatId = chatId;
		MessageId = messageId;
		OriginalText = originalText;
		ReplyText = replyText;
	}

	public long UserId { get; }

	public long ChatId { get; }

	public int MessageId { get; }

	public string OriginalText { get; }

	public string ReplyText { get; }
}
