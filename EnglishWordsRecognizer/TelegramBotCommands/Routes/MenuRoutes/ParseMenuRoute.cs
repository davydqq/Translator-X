using Microsoft.Extensions.Options;
using TB.Menu.Commands;
using TB.Menu.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Entities;

namespace TelegramBotCommands.Commands.MenuCommands;

public class ParseMenuRoute : IBaseRoute
{     
    private readonly IOptions<BotMenuConfig> config;
    private readonly BaseCommandOptions options;

    public ParseMenuRoute(IOptions<BotMenuConfig> config, BaseCommandOptions options)
	{
		this.config = config;
        this.options = options;
    }

	public int Order => 1;

	public bool CanHandle(Update update)
	{
        if (update == null || update.Message == null)
            return false;

        var message = update.Message;
        if (string.IsNullOrEmpty(message.Text))
            return false;

        if (message.Type != MessageType.Text)
            return false;

        return config.Value.Commands.Any(command => message.Text.Contains(command.Name));
    }

	public BaseRouteResult Execute(Update update)
	{
        var message = update.Message;
        var command = config.Value.Commands.First(command => message.Text.Contains(command.Name));

        var userId = update.Message!.From!.Id;

        var chatId = options?.ChatId ?? message.Chat.Id;
        var messageId = options?.MessageId ?? message.MessageId;

        var commandToExecute = new HandleMenuCommand(command, chatId, messageId, userId, options.IsDeleteCurrentMessage);

        return new BaseRouteResult(commandToExecute);
    }
}
