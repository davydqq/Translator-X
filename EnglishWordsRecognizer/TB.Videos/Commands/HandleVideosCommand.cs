using CQRS.Commands;
using TB.Common;

namespace TB.Videos.Commands;

public class HandleVideosCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleVideosCommand(long chatId, long userId, int messageId) : base(chatId, userId, messageId)
    {
    }
}
