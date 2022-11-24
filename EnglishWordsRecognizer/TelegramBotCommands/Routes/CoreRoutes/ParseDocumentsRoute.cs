using TB.Documents.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseDocumentsRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Document;
    }

    public BaseRouteResult Execute(Update update)
    {
        return new BaseRouteResult(new HandleDocumentsCommand());
    }
}
