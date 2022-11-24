using TB.Audios.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseAudiosCommand : BaseCommand
{
    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        return message.Type == MessageType.Audio || message.Type == MessageType.Voice;
    }

    public override BaseCommandResult Execute(Update update)
    {
        var command = new HandleAudiosCommand();
        return new BaseCommandResult(command);
    }
}
