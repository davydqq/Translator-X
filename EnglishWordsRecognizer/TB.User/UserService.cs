using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Common;
using TB.MemoryStorage;
using TB.Menu.Commands;
using TB.Menu.Entities;

namespace TB.User;

public class UserService : IUserService
{
    private readonly Storage memoryStorage;
    private readonly ICommandDispatcher commandDispatcher;
    private readonly IOptions<BotMenuConfig> menuConfig;

    public UserService(
        Storage memoryStorage, 
        ICommandDispatcher commandDispatcher,
        IOptions<BotMenuConfig> menuConfig)
    {
        this.memoryStorage = memoryStorage;
        this.commandDispatcher = commandDispatcher;
        this.menuConfig = menuConfig;
    }


    public async Task<bool> ValidateThatUserSelectLanguages(BaseTelegramMessageCommand command)
    {
        var isTargetLangugeSetted = memoryStorage.IsTargetLanguageSetted(command.UserId);
        if (!isTargetLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        var isNativeLangugeSetted = memoryStorage.IsNativeLanguageSetted(command.UserId);
        if (!isNativeLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        return true;
    }
}
