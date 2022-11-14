using Telegram.Bot.Types;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands;

public class ChangeLanguageCommand : BaseCallBackCommand
{
    public override Task HandleIternalCommand(CallbackQuery query, FacadTelegramBotService service)
    {
        var language = GetLanguage(query.Data!);
        service.AddOrUpdateUserLanguage(query.From.Id, language);

        return Task.CompletedTask;
    }

    public LanguageENUM GetLanguage(string data)
    {
        if (data.StartsWith("LanguageId-"))
        {
            var id = data.Split("-").ElementAt(1);
            if(Enum.TryParse(id, out LanguageENUM lang))
            {
                return lang;
            }
        }

        return LanguageENUM.Ukrainian;
    }
}
