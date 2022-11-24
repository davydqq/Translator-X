using TB.Videos.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseVideosCommand : BaseCommand
{
    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        return message.Type == MessageType.Video;
    }

    public override BaseCommandResult Execute(Update update)
    {
        return new BaseCommandResult(new HandleVideosCommand());
    }
}
