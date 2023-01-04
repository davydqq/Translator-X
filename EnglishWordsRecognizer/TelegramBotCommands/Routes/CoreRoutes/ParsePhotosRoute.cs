using TB.Common;
using TB.Images.Commands;
using TB.Routing.Entities;
using Telegram.Bot.Types;

namespace TB.Routing.Routes.CoreRoutes;

public class ParsePhotosRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        return TelegramMessageContentHelper.IsPhotoRoute(update.Message);
    }

    public BaseRouteResult<bool> GetCommand(Update update)
    {
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = TelegramMessageContentHelper.GetPhotos(message);

        var command = new HandleImagesCommand(chatId, userId, messageId, message.Caption, files, update);
        return new BaseRouteResult<bool>(command);
    }

}
