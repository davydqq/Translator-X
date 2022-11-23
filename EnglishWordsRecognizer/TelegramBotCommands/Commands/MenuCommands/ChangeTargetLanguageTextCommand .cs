using TB.Menu.Commands;
using TB.Menu;
using Telegram.Bot.Types;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.MenuCommands;


public class ChangeTargetLanguageTextCommandOptions : BaseCommandOptions
{

}

public class ChangeTargetLanguageTextCommand : BaseTextCommand
{
    public ChangeTargetLanguageTextCommandOptions options;

    public override string Name => CommandsNames.LanguageTarget;

    public override int Order => 3;

    public ChangeTargetLanguageTextCommand(ChangeTargetLanguageTextCommandOptions options)
    {
        this.options = options;
    }

    public override TextInternalCommandResult HandleTextInternalCommand(Update update)
    {
        var message = update.Message;
        var userId = update.Message!.From!.Id;

        var chatId = options?.ChatId ?? message.Chat.Id;
        var messageId = options?.MessageId ?? message.MessageId;

        var command = new SendMenuCommand(BotMenuId.TargetLanguage, chatId, messageId, userId, options.IsDeleteCurrentMessage);
        return new TextInternalCommandResult { Command = command };
    }
}
