using Telegram.Bot.Types;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CallbackCommands;


public class ChangeNativeLanguageCommandOptions : BaseCommandOptions
{

}

public class ChangeNativeLanguageCallbackCommand : BaseCallBackCommand
{
    private ChangeNativeLanguageCommandOptions options;

    public override string CallBackId => ChangeNativeLanguageTextCommand.callBackId;

    public ChangeNativeLanguageCallbackCommand(ChangeNativeLanguageCommandOptions options)
    {
        this.options = options;
    }

    public override async Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var res = new CallbackInternalCommandResult();

        var query = update.CallbackQuery;

        var language = GetLanguage(query.Data!);
        if (language.HasValue)
        {
            service.AddOrUpdateUserNativeLanguage(query.From.Id, language.Value);
        }

        if (!service.IsLanguageSetted(query.From.Id))
        {
            var options = new ChangeTargetLanguageTextCommandOptions { ChatId = query.Message.Chat.Id, MessageId = query.Message.MessageId, IsDeleteCurrentMessage = true };
            var command = new ChangeTargetLanguageTextCommand(options);

            await command.ExecuteAsync(update, service);
        }

        res.IsExecuted = true;

        return res;
    }


    public LanguageENUM? GetLanguage(string data)
    {
        var id = data.Split("-").ElementAt(1);
        if (Enum.TryParse(id, out LanguageENUM lang))
        {
            return lang;
        }

        return null;
    }
}
