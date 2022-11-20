using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;
using TelegramBotManager;
using TelegramBotStorage;

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
        var isTargetLangugeSetted = service.IsTargetLanguageSetted(update.Message.From.Id);

        if (!isTargetLangugeSetted)
        {
            var options = new ChangeTargetLanguageTextCommandOptions { ChatId = update.Message.Chat.Id };
            var command = new ChangeTargetLanguageTextCommand(options);
            await command.ExecuteAsync(update, service);

            return new BaseCommandResult();
        }

        var languageToId = service.GetUserTargetLanguage(update.Message.From.Id);
        var languageTo = SupportedLanguages.languagesDict[languageToId];

        var res = await service.textProcessService.ProcessTextAsync(update.Message.Text, languageTo.Code);

        var text = string.Join("\n", res.SelectMany(x => x.Translations).Select(x => x.Text));
        if(!string.IsNullOrEmpty(text))
        {
            await service.SendMessageAsync(update.Message.Chat.Id, text, ParseMode.Markdown);
        }
       
        return new BaseCommandResult();
    }
}
