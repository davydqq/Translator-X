using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands;

public abstract class BaseTextCommand : BaseCommand
{
    public abstract string Name { get; }

    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        if (string.IsNullOrEmpty(message.Text))
            return false;
        
        if (message.Type != MessageType.Text)
            return false;

        return message.Text.Contains(this.Name);
    }

    public async override Task ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        await HandleTextCommandAsync(update!, service);
    }

    public abstract Task HandleTextCommandAsync(Update update, FacadTelegramBotService service);
}
