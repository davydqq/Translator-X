using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotCommands.Services;

namespace TelegramBotManager;

public abstract class BaseCommand
{
    public abstract Task Execute(Update update, FacadTelegramBotService service);

    public abstract bool CanHandle(Update update);
}
