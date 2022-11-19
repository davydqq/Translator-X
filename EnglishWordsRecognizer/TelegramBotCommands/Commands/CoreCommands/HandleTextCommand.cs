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
        throw new NotImplementedException();
    }

    public override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        throw new NotImplementedException();
    }
}
