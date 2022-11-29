using CQRS.Commands;
using TB.Common;
using TB.Menu.Entities;

namespace TB.Menu.Commands;

public class HandleMenuCommand : BaseTelegramMessageCommand, ICommand
{
	public HandleMenuCommand(BotMenuCommand command, long chatId, int messageId, long userId, bool deleteMessage)
		:base(chatId, userId, messageId)
	{
        MenuCommand = command;
		DeleteMessage = deleteMessage;
	}

	public BotMenuCommand MenuCommand { get; }

	public bool DeleteMessage { get; }
}
