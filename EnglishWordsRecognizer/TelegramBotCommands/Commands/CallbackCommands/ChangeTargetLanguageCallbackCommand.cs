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

    public override int Order => 1;

    public ChangeTargetLanguageCallbackCommand(ChangeTargetLanguageCallbackCommandOptions options)
    {
        this.options = options;
    }

    public async override Task<CallbackInternalCommandResult> HandleIternalCommand(Update update, FacadTelegramBotService service)
    {
        var res = new CallbackInternalCommandResult();

        var query = update.CallbackQuery;
        var chatId = query.Message.Chat.Id;
        var userId = query.From.Id;

        if (options.IsDeleteCurrentMessage)
        {
            await service.DeleteMessageAsync(chatId, query.Message.MessageId);
        }

        var language = GetLanguage(query.Data!);
        if (language.HasValue)
        {
            service.AddOrUpdateUserTargetLanguage(userId, language.Value);
        }

        if (service.LanguagesInited(userId))
        {
            await service.SendLanguagesWereEstablished(chatId, userId);
        }

        if (!service.IsNativeLanguageSetted(userId))
        {
            var options = new ChangeNativeLanguageTextCommandOptions { ChatId = chatId, MessageId = query.Message.MessageId };
            var command = new ChangeNativeLanguageTextCommand(options);

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
