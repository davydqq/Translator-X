using Telegram.Bot.Types;
using TelegramBotCommands.Services;

namespace TelegramBotCommands.Commands.MenuCommands;

public class StartTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Start;

    public override async Task HandleTextCommandAsync(Update update, FacadTelegramBotService service)
    {
        var changeNativeLanguageCommand = new ChangeNativeLanguageTextCommand();
        await changeNativeLanguageCommand.ExecuteAsync(update, service);
    }
}
