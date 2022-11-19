using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandleAudiosCommand : BaseCommand
{
    public override int Order => 25;

    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Audio || message.Type != MessageType.Voice)
            return false;

        return true;
    }

    public override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        return Task.FromResult(new BaseCommandResult());
    }
}
