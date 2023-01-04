using CQRS.Commands;
using TB.Common;
using Telegram.Bot.Types;

namespace TB.Documents.Commands;

public class HandleDocumentsCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleDocumentsCommand(long chatId, long userId, int messageId, Update update) : base(chatId, userId, messageId, update)
    {
    }
}
