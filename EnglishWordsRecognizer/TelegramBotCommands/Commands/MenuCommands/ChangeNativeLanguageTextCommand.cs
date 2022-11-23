using TB.Menu.Commands;
using TB.Menu;
using Telegram.Bot.Types;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.MenuCommands;

public class ChangeNativeLanguageTextCommandOptions : BaseCommandOptions
{

}

public class ChangeNativeLanguageTextCommand : BaseTextCommand
{
    public override string Name => CommandsNames.LanguageNative;

    public override int Order => 2;

    public ChangeNativeLanguageTextCommandOptions options;

    public ChangeNativeLanguageTextCommand(ChangeNativeLanguageTextCommandOptions options)
    {
        this.options = options;
    }

    public override TextInternalCommandResult HandleTextInternalCommand(Update update)
    {
        var message = update.Message;
        var userId = update.Message!.From!.Id;

        var chatId = options?.ChatId ?? message.Chat.Id;
        var messageId = options?.MessageId ?? message.MessageId;

        var command = new SendMenuCommand(BotMenuId.NativeLanguage, chatId, messageId, userId, options.IsDeleteCurrentMessage);
        return new TextInternalCommandResult { Command = command };
    }
}
