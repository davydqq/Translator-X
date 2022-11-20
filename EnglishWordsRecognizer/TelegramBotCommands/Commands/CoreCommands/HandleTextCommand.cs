using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandleTextCommand : BaseCommand
{
    public override int Order => 10;

    public override bool CanHandle(Update update)
    {
        return false;
    }

    public override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        return Task.FromResult(new BaseCommandResult());
    }
}
