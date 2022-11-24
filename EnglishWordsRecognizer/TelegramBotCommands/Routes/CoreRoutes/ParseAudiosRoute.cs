using TB.Audios.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseAudiosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Audio || message.Type == MessageType.Voice;
    }

    public BaseRouteResult Execute(Update update)
    {
        var command = new HandleAudiosCommand();
        return new BaseRouteResult(command);
    }
}
