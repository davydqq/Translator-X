using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotManager;
using TelegramBotCommands.Services;

namespace TelegramBotCommands;

public abstract class BaseCallBackCommand : BaseCommand
{
    public override bool CanHandle(Update update)
    {
        if (update != null && update.Type == UpdateType.CallbackQuery)
            return true;

        return false;
    }

    public async override Task Execute(Update update, FacadTelegramBotService service)
    {
        await HandleIternalCommand(update.CallbackQuery!, service);
    }

    public abstract Task HandleIternalCommand(CallbackQuery query, FacadTelegramBotService service);
}
