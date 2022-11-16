using Telegram.Bot.Types;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CallbackCommands;


public class ChangeNativeLanguageCallbackCommandOptions : BaseCommandOptions
{

}

public class ChangeNativeLanguageCallbackCommand : BaseCallBackCommand
{
    private ChangeNativeLanguageCallbackCommandOptions options;

    public override Task HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var query = update.CallbackQuery;

        if (IsCanHandle(query.Data))
        {
            var language = GetLanguage(query.Data!);
            if (language.HasValue)
            {
                service.AddOrUpdateUserNativeLanguage(query.From.Id, language.Value);
            }
        }

        return Task.CompletedTask;
    }

    public void AddOptions(ChangeNativeLanguageCallbackCommandOptions options)
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
