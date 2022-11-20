using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandleStickersCommand : BaseCommand
{
    public override int Order => 16;

    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Sticker)
            return false;

        return true;
    }

    public async override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        // TODO add validation accepted types;

        var bytes = await service.DownloadFileAsync(update.Message.Sticker.FileId);

        var resAnalys = await service.imageProcessService.AnalyzeImage(bytes);
        var resOCR = await service.imageProcessService.OCRImage(bytes);

        return new BaseCommandResult();
    }
}
