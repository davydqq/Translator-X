using CQRS.Commands;
using Telegram.Bot.Types;

namespace TelegramBotCommands;

public class TelegramUpdatesCommand : ICommand
{
	public Update Update { set; get; }

	public TelegramUpdatesCommand(Update update)
	{
		this.Update = update;
	}
}
