using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Audios.Commands;

public class HandleAudiosCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleAudiosCommand(long chatId, long userId, int messageId, AudioInfo file, Update update) 
        : base(chatId, userId, messageId, update)
    {
        File = file;
    }

    public AudioInfo File { set; get; }
}
