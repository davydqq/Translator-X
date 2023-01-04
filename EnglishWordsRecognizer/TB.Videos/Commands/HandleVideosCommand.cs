using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Videos.Commands;

public class HandleVideosCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleVideosCommand(long chatId, long userId, int messageId, Update update) : base(chatId, userId, messageId, update)
    {
    }
}
