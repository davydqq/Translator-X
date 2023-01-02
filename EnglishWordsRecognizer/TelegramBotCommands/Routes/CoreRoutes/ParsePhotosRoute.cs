using TB.Audios.Entities;
using TB.Common;
using TB.Images.Commands;
using TB.Images.Entities;
using TB.Routing;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.CoreRoutes;

public class ParsePhotosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Photo || isPhotoFile(message);
    }

    private bool isPhotoFile(Message message)
    {
        var formats = PhotosFormats.GetFormats();
        return message.Type == MessageType.Document && formats.Contains(message.Document.MimeType);
    }

    public BaseRouteResult GetCommand(Update update)
    {
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = GetPhotos(message);

        var command = new HandleImagesCommand(chatId, userId, messageId, message.Caption, files);
        return new BaseRouteResult(command);
    }

    private List<ImagesInfo> GetPhotos(Message message)
    {
        switch (message.Type)
        {
            case MessageType.Photo:
                {
                    return message.Photo.Select(x => new ImagesInfo(x.FileId, x.FileSize)).ToList();
                }
            case MessageType.Document:
                {
                    return new List<ImagesInfo> { new ImagesInfo(message.Document.FileId, message.Document.FileSize) };
                }
            default:
                {
                    throw new ArgumentException("Incorrect type");
                }
        }
    }
}
