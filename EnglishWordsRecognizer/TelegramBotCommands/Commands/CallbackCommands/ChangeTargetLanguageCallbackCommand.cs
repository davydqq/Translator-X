using Telegram.Bot.Types;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CallbackCommands;

public class ChangeTargetLanguageCallbackCommand : BaseCallBackCommand
{
    public override Task HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var query = update.CallbackQuery;

        if (IsCanHandle(query.Data))
        {
            var language = GetLanguage(query.Data!);
            if (language.HasValue)
            {
                service.AddOrUpdateUserTargetLanguage(query.From.Id, language.Value);
            }
        }

        return Task.CompletedTask;
    }

    public bool IsCanHandle(string data)
    {
        if (!string.IsNullOrEmpty(data) && data.StartsWith(ChangeTargetLanguageTextCommand.callBackId))
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
