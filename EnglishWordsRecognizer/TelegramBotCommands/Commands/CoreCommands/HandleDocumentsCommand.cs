using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandleDocumentsCommand : BaseCommand
{
    public override int Order => 20;

    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Document)
            return false;

        return true;
    }

    public override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        return Task.FromResult(new BaseCommandResult());
    }
}
