using Microsoft.Extensions.Options;
using TB.Menu.Commands;
using TB.Menu.Entities;
using TB.Routing.Entities;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Routing.Routes.MenuRoutes;

public class ParseMenuRoute : IBaseRoute
{
    private readonly IOptions<BotMenuConfig> config;

    public ParseMenuRoute(IOptions<BotMenuConfig> config)
    {
        this.config = config;
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

    public BaseRouteResult<bool> GetCommand(Update update)
    {
        var message = update.Message;
        var command = config.Value.Commands.First(command => message.Text.Contains(command.Name));

        var userId = update.Message!.From!.Id;

        var chatId =  message.Chat.Id;
        var messageId = message.MessageId;

        var commandToExecute = new HandleMenuCommand(command, chatId, messageId, userId, true);

        return new BaseRouteResult<bool>(commandToExecute);
    }
}
