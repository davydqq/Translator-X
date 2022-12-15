using CQRS.Commands;
using Telegram.Bot.Types;

namespace TB.User.Commands;

public class RegisterUserCommand : ICommand
{
    public Update Update { set; get; }

	public RegisterUserCommand(Update update)
	{
		Update = update;
	}
}
