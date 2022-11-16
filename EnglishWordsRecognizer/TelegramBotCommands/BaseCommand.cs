using Telegram.Bot.Types;
using TelegramBotCommands.Services;

namespace TelegramBotManager;

public abstract class BaseCommand
{
    public abstract Task ExecuteAsync(Update update, FacadTelegramBotService service);

    public abstract bool CanHandle(Update update);
}
