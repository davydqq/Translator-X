using TB.Images.Commands;
using TB.Images.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class ParsePhotosCommand : BaseCommand
{
	public override bool CanHandle(Update update)
	{
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        return message.Type == MessageType.Photo;
    }

	public override BaseCommandResult Execute(Update update)
	{
        var message = update.Message;
        var userId = message!.From!.Id;
        var chatId = message.Chat.Id;
        var messageId = message.MessageId;

        var files = message.Photo.Select(x => new ImagesInfo(x.FileId, x.FileSize)).ToList();

        var command = new HandleImagesCommand(chatId, userId, messageId, files);
        return new BaseCommandResult(command);
	}

}
