using Telegram.Bot.Types;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;

namespace TelegramBotCommands.Commands.MenuCommands;

public class StartTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Start;

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var res = new TextInternalCommandResult() { IsExecuted = true };

        var changeNativeLanguageCommand = new ChangeNativeLanguageTextCommand();
        await changeNativeLanguageCommand.ExecuteAsync(update, service);

        return res;
    }
}
