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

        var options = new ChangeNativeLanguageTextCommandOptions() { IsDeleteCurrentMessage = true };
        var changeNativeLanguageCommand = new ChangeNativeLanguageTextCommand(options);
        await changeNativeLanguageCommand.ExecuteAsync(update, service);

        InitLanguageSetuping(update, service);

        return res;
    }

    private void InitLanguageSetuping(Update update, FacadTelegramBotService service)
    {
        service.AddOrUpdateUserSettedLanguage(update.Message!.From!.Id, false);
    }
}
