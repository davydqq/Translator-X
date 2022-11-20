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
        var bot = await service.GetBotClientAsync();
        var file = await bot.GetFileAsync(update.Message.Sticker.FileId);
        using var ms = new MemoryStream();
        await bot.DownloadFileAsync(file.FilePath, ms);
        var res = await service.imageProcessService.AnalyzeImage(ms);
        return new BaseCommandResult();
    }
}
