using CQRS.Commands;
using TB.Common;

namespace TB.Texts.Commands;

public class HandleTextsCommand : BaseTelegramMessageCommand, ICommand
{
	public HandleTextsCommand(long chatId, long userId, int messageId, string text, int? replyId = null) 
		: base(chatId, userId, messageId)
	{
		Text = text;
		ReplyId = replyId;
	}

	public string Text { get; }

	public int? ReplyId { get; }
}
