using TB.Callbacks.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.CallbackCommands;

public class ParseCallbackRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null) return false;

        var data = update.CallbackQuery?.Data;
        if (!string.IsNullOrEmpty(data) && update.Type == UpdateType.CallbackQuery)
        {
            return true;
        }

        return false;
    }

    public BaseRouteResult Execute(Update update)
    {
        var query = update.CallbackQuery;

        var chatId = query.Message.Chat.Id;
        var userId = query.From.Id;
        var messageId = query.Message.MessageId;
        var data = query.Data;

        var command = new HandleCallbackCommand(chatId, userId, messageId, data);

        return new BaseRouteResult(command);
    }
}
