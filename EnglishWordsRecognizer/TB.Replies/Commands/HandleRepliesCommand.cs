using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Replies.Commands;

public class HandleRepliesCommand : BaseTelegramMessageCommand, ICommand<bool>
{
	public HandleRepliesCommand(long userId, long chatId, int messageId, Message replyMessage, string originalText, Update update)
		 : base(chatId, userId, messageId, update)
	{
		ReplyMessage = replyMessage;
		OriginalText = originalText;
	}

	public Message ReplyMessage { get; }

    public string OriginalText { get; }
}
