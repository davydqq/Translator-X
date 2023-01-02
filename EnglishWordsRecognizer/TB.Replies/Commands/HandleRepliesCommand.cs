using CQRS.Commands;
using TB.Common;

namespace TB.Replies.Commands;

public class HandleRepliesCommand : BaseTelegramMessageCommand, ICommand<bool>
{
	public HandleRepliesCommand(long userId, long chatId, int messageId, string originalText, string replyText)
         : base(chatId, userId, messageId)
    {
		OriginalText = originalText;
		ReplyText = replyText;
	}

	public string OriginalText { get; }

	public string ReplyText { get; }
}
