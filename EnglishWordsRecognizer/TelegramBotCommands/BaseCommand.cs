using Telegram.Bot.Types;
using TelegramBotCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;

namespace TelegramBotManager;

public abstract class BaseCommand : IBaseCommand
{
    public abstract Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service);

    public abstract bool CanHandle(Update update);
}
