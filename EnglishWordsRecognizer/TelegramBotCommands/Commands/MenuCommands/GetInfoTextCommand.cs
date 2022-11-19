using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotCommands.Services;
using Telegram.Bot;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.MenuCommands;

public class GetInfoTextCommandOptions : BaseCommandOptions
{

}

public class GetInfoTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.Info;

    public override int Order => 4;

    public GetInfoTextCommandOptions options;

    public GetInfoTextCommand(GetInfoTextCommandOptions options)
    {
        this.options = options;
    }

    public override bool CanHandle(Update update)
    {
        if (update.Message == null || update.Message.Chat == null)
            return false;

        return true;
    }

    public override async Task<TextInternalCommandResult> HandleTextInternalCommandAsync(Update update, FacadTelegramBotService service)
    {
        var message = update.Message;
        var botClient = await service.GetBotClientAsync();
        await botClient.SendTextMessageAsync(
           message!.Chat.Id,
           $"Info",
           parseMode: ParseMode.Html
       );

        return new TextInternalCommandResult { IsExecuted = true };
    }
}
