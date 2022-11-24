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
        return message.Type == MessageType.Photo;
    }

    public BaseRouteResult GetCommand(Update update)
    {
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = message.Photo.Select(x => new ImagesInfo(x.FileId, x.FileSize)).ToList();

        var command = new HandleImagesCommand(chatId, userId, messageId, files);
        return new BaseRouteResult(command);
    }
}
