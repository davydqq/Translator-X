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

    public override Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var res = new CallbackInternalCommandResult();

        var query = update.CallbackQuery;

        if (IsCanHandle(query.Data))
        {
            var language = GetLanguage(query.Data!);
            if (language.HasValue)
            {
                service.AddOrUpdateUserNativeLanguage(query.From.Id, language.Value);
            }
            res.IsExecuted = true;
        }

        return Task.FromResult(res);
    }

    public void AddOptions(ChangeNativeLanguageCommandOptions options)
    {
        this.options = options;
    }

    public bool IsCanHandle(string data)
    {
        if (!string.IsNullOrEmpty(data) && data.StartsWith(ChangeNativeLanguageTextCommand.callBackId))
        {
            return true;
        }

        return false;
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
