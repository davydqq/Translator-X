using TB.Common;
using TB.Documents.Commands;
using TB.Routing;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParseDocumentsRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Document && !isAudioFile(message) && !isPhotoFile(message);
    }

    private bool isAudioFile(Message message)
    {
        var formats = AudiosFormats.GetFormats();
        return message.Document != null && formats.Contains(message.Document.MimeType);
    }

    private bool isPhotoFile(Message message)
    {
        var formats = PhotosFormats.GetFormats();
        return message.Type == MessageType.Document && formats.Contains(message.Document.MimeType);
    }

    public BaseRouteResult GetCommand(Update update)
    {
        var message = update.Message;

        var userId = message.From.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        return new BaseRouteResult(new HandleDocumentsCommand(chatId, userId, messageId));
    }
}
