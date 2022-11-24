using TB.Images.Commands;
using TB.Images.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParseStickersCommand : BaseCommand
{
    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Sticker;
    }

    public override BaseCommandResult Execute(Update update)
    {
        // TODO add validation accepted types;

        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = new List<ImagesInfo>
        {
            new ImagesInfo(message.Sticker.FileId, message.Sticker.FileSize)
        };

        var command = new HandleImagesCommand(chatId, userId, messageId, files);
        return new BaseCommandResult(command) ;
    }
}
