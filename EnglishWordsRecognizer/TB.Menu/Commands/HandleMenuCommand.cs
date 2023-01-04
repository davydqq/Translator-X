using CQRS.Commands;
using TB.Common;
using TB.Menu.Entities;
using Telegram.Bot.Types;

namespace TB.Menu.Commands;

public class HandleMenuCommand : BaseTelegramMessageCommand, ICommand<bool>
{
	public HandleMenuCommand(BotMenuCommand command, long chatId, int messageId, long userId, bool deleteMessage, Update update)
		:base(chatId, userId, messageId, update)
	{
        MenuCommand = command;
		DeleteMessage = deleteMessage;
	}

	public BotMenuCommand MenuCommand { get; }

	public bool DeleteMessage { get; }
}
