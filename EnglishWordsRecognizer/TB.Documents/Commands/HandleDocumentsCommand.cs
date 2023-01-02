using CQRS.Commands;
using TB.Common;

namespace TB.Documents.Commands;

public class HandleDocumentsCommand : BaseTelegramMessageCommand, ICommand<bool>
{
    public HandleDocumentsCommand(long chatId, long userId, int messageId) : base(chatId, userId, messageId)
    {
    }
}
