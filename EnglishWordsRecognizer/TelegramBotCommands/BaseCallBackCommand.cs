using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotManager;
using TelegramBotCommands.Services;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands;

public abstract class BaseCallBackCommand : BaseCommand
{
    public override bool CanHandle(Update update)
    {
        if (update != null && update.Type == UpdateType.CallbackQuery)
            return true;

        return false;
    }


    public async override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
       var res = await HandleIternalCommand(update, service);

        return new BaseCommandResult() { IsExecuted = true };
    }

    public abstract Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service);
}
