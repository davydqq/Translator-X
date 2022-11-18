using Telegram.Bot.Types;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CallbackCommands;

public class ChangeTargetLanguageCallbackCommand : BaseCallBackCommand
{
    public override Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var res = new CallbackInternalCommandResult();

        var query = update.CallbackQuery;

        if (IsCanHandle(query.Data))
        {
            var language = GetLanguage(query.Data!);
            if (language.HasValue)
            {
                service.AddOrUpdateUserTargetLanguage(query.From.Id, language.Value);
            }

            if (service.LanguagesInited(query.From.Id))
            {
                service.AddOrUpdateUserSettedLanguage(query.From.Id, true);
            }

            res.IsExecuted = true;
        }

        return Task.FromResult(res);
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
