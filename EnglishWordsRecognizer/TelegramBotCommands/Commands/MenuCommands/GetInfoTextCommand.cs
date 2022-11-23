using Telegram.Bot.Types;
using TelegramBotCommands.Entities;
using TB.Menu.Commands;
using TB.Menu;

namespace TelegramBotCommands.Commands.MenuCommands;

public class GetInfoTextCommandOptions : BaseCommandOptions
{

}

public class GetInfoTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Info;

    public override int Order => 4;

    public GetInfoTextCommandOptions options;

    public GetInfoTextCommand(GetInfoTextCommandOptions options)
    {
        this.options = options;
    }

    public override TextInternalCommandResult HandleTextInternalCommand(Update update)
    {
        var message = update.Message;
        var userId = update.Message!.From!.Id;
        var command = new SendMenuCommand(BotMenuId.Info, message!.Chat.Id, message.MessageId, userId, options.IsDeleteCurrentMessage);
        return new TextInternalCommandResult { Command = command };
    }
}
