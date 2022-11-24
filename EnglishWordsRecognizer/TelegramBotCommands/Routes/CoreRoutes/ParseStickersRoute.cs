using TB.Images.Commands;
using TB.Images.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseStickersRoute : IBaseRoute
{
    public int Order => 2;

    public bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Sticker;
    }

    public BaseRouteResult Execute(Update update)
    {
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = new List<ImagesInfo>
        {
            new ImagesInfo(message.Sticker.FileId, message.Sticker.FileSize)
        };

        var command = new HandleImagesCommand(chatId, userId, messageId, files);
        return new BaseRouteResult(command) ;
    }
}
