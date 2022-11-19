using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CallbackCommands;

public class ChangeTargetLanguageCallbackCommandOptions : BaseCommandOptions
{

}

public class ChangeTargetLanguageCallbackCommand : BaseCallBackCommand
{
    private readonly ChangeTargetLanguageCallbackCommandOptions options;

    public override string CallBackId => ChangeTargetLanguageTextCommand.callBackId;

    public ChangeTargetLanguageCallbackCommand(ChangeTargetLanguageCallbackCommandOptions options)
    {
        this.options = options;
    }

    public async override Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var res = new CallbackInternalCommandResult();

        var query = update.CallbackQuery;

        var language = GetLanguage(query.Data!);
        if (language.HasValue)
        {
            service.AddOrUpdateUserTargetLanguage(query.From.Id, language.Value);
        }

        if (service.LanguagesInited(query.From.Id))
        {
            service.AddOrUpdateUserSettedLanguage(query.From.Id, true);
            await service.SendMessageAsync(query.Message.Chat.Id, $"The languages was established.\nYou can send text, photo, audio for translating.", ParseMode.Html);
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
