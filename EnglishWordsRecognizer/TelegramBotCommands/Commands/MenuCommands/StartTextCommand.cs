using Telegram.Bot.Types;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;

namespace TelegramBotCommands.Commands.MenuCommands;


public class StartTextCommandOptions : BaseCommandOptions
{

}

public class StartTextCommand : BaseTextCommand
{
    private readonly StartTextCommandOptions options;

    public override string Name => CommandsNames.Start;

    public override int Order => 1;

    public StartTextCommand(StartTextCommandOptions options)
    {
        this.options = options;
    }

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var res = new TextInternalCommandResult() { IsExecuted = true };

        if (options.IsDeleteCurrentMessage)
        {
            await service.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId);
        }

        InitLanguageSetuping(update, service);

        var options2 = new ChangeNativeLanguageTextCommandOptions();
        var changeNativeLanguageCommand = new ChangeNativeLanguageTextCommand(options2);
        await changeNativeLanguageCommand.ExecuteAsync(update, service);

        return res;
    }

    private void InitLanguageSetuping(Update update, FacadTelegramBotService service)
    {
        service.AddOrUpdateUserSettedLanguage(update.Message!.From!.Id, false);
    }
}
