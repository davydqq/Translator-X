using TB.Menu.Commands;
using TB.Menu;
using Telegram.Bot.Types;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.MenuCommands;


public class StartTextCommandOptions : BaseCommandOptions
{

}

public class StartTextCommand : BaseTextCommand
{
    private readonly StartTextCommandOptions options;

    public override string Name => CommandsNames.Start;

    public override int Order => 1;

    public StartTextCommand(StartTextCommandOptions options)
    {
        this.options = options;
    }

    public override TextInternalCommandResult HandleTextInternalCommand(Update update)
    {
        var message = update.Message;
        var userId = update.Message!.From!.Id;
        var command = new SendMenuCommand(BotMenuId.Start, message!.Chat.Id, message.MessageId, userId, options.IsDeleteCurrentMessage);
        return new TextInternalCommandResult { Command = command };
    }
}
