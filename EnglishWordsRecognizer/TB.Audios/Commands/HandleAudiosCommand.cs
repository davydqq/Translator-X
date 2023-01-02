using CQRS.Commands;
using TB.Audios.Entities;
using TB.Common;

namespace TB.Audios.Commands;

public class HandleAudiosCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleAudiosCommand(long chatId, long userId, int messageId, AudioInfo file) 
        : base(chatId, userId, messageId)
    {
        File = file;
    }

    public AudioInfo File { set; get; }
}
