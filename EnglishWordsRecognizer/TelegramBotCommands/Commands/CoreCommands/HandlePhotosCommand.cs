using System.Collections;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;
using File = System.IO.File;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandlePhotosCommand : BaseCommand
{
	public HandlePhotosCommand()
	{

	}

	public override int Order => 15;

	public override bool CanHandle(Update update)
	{
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Photo)
            return false;

        return true;
    }

	public async override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
	{
        // TODO add validation accepted types;

        var bot = await service.GetBotClientAsync();
        var photos = update.Message.Photo;
        var maxPhoto = photos.MaxBy(x => x.FileSize);

        var bytes = await service.DownloadFileAsync(maxPhoto.FileId);

        var resAnalys = await service.imageProcessService.AnalyzeImage(bytes);
        var resOCR = await service.imageProcessService.OCRImage(bytes);

        return new BaseCommandResult();
	}

}
