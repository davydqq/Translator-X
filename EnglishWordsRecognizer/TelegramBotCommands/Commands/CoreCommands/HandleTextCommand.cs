using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;
using TelegramBotStorage;
using static System.Net.Mime.MediaTypeNames;
using TelegramBotStorage.Languages;

namespace TelegramBotCommands.Commands.CoreCommands;

public class HandleTextCommand : BaseCommand
{
    public override int Order => 10;

    public override bool CanHandle(Update update)
    {
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;

        if (message.Type != MessageType.Text)
            return false;

        return true;
    }

    public async override Task<BaseCommandResult> ExecuteAsync(Update update, FacadTelegramBotService service)
    {
        if(!string.IsNullOrEmpty(update.Message?.From?.Id.ToString()) ||
            !string.IsNullOrEmpty(update.Message?.Chat?.Id.ToString()))
        {
            return new BaseCommandResult { IsExecuted = false };
        }

        var userId = update.Message.From.Id;
        var chatId = update.Message.Chat.Id;

        var isTargetLangugeSetted = service.IsTargetLanguageSetted(userId);
        if (!isTargetLangugeSetted)
        {
            var options = new ChangeTargetLanguageTextCommandOptions { ChatId = chatId };
            var command = new ChangeTargetLanguageTextCommand(options);
            await command.ExecuteAsync(update, service);

            return new BaseCommandResult();
        }

        var isNativeLangugeSetted = service.IsNativeLanguageSetted(userId);
        if (!isNativeLangugeSetted)
        {
            var options = new ChangeNativeLanguageTextCommandOptions { ChatId = chatId };
            var command = new ChangeNativeLanguageTextCommand(options);
            await command.ExecuteAsync(update, service);

            return new BaseCommandResult();
        }

        var languageToId = service.GetUserTargetLanguage(userId);
        var languageTo = SupportedLanguages.languagesDict[languageToId];

        // PROCESSING
        var text = update.Message.Text;

        var resDetect = await service.textProcessService.DetectLanguagesAsync(text);

        if(resDetect.Count > 0 && languageTo.Code == resDetect.First().Language)
        {
            var languageFromId = service.GetUserTargetLanguage(userId);
            var languageFrom = SupportedLanguages.languagesDict[languageFromId];

            var resTextFrom = await GetTranslationsAsync(service, text, languageFrom.Code);
            await SendTransalitonToClientAsync(service, chatId, resTextFrom);

            return new BaseCommandResult();
        }

        var resText = await GetTranslationsAsync(service, text, languageTo.Code);
        await SendTransalitonToClientAsync(service, chatId, resText);
       
        return new BaseCommandResult();
    }

    private async Task SendTransalitonToClientAsync(FacadTelegramBotService service, long chatId, string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            await service.SendMessageAsync(chatId, text, ParseMode.Markdown);
        }
    }

    private async Task<string> GetTranslationsAsync(FacadTelegramBotService service, string text, string langCode)
    {
        var res = await service.textProcessService.ProcessTextAsync(text, langCode);
        var resText = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        return resText;
    }
}
