using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Texts.Commands;

public class HandleTextsCommand : BaseTelegramMessageCommand, ICommand<bool>
{
	public HandleTextsCommand(long chatId, long userId, int messageId, string text, Update update, int? replyId = null) 
		: base(chatId, userId, messageId, update)
	{
		Text = text;
		ReplyId = replyId;
	}

	public string Text { get; }

	public int? ReplyId { get; }
}
