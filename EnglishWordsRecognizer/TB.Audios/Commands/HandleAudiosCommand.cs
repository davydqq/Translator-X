using CQRS.Commands;
using TB.Common;

namespace TB.Audios.Commands;

public class HandleAudiosCommand : BaseTelegramMessageCommand, ICommand
{
    public HandleAudiosCommand(long chatId, long userId, int messageId) 
        : base(chatId, userId, messageId)
    {
    }
}
