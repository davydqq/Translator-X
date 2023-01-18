using CQRS.Commands;
using Microsoft.Extensions.Options;
using TB.Common;
using TB.Database.Entities.Users;
using TB.Database.GenericRepositories;
using TB.Menu.Commands;
using TB.Menu.Entities;

namespace TB.User;

public class UserService : IUserService
{
    private readonly ICommandDispatcher commandDispatcher;

    private readonly IOptions<BotMenuConfig> menuConfig;

    private readonly IRepository<UserSettings, int> repositoryUserSettings;

    public UserService(
        ICommandDispatcher commandDispatcher,
        IOptions<BotMenuConfig> menuConfig,
        IRepository<UserSettings, int> repositoryUserSettings)
    {
        this.commandDispatcher = commandDispatcher;
        this.menuConfig = menuConfig;
        this.repositoryUserSettings = repositoryUserSettings;
    }


    public async Task<bool> ValidateThatUserSelectLanguages(BaseTelegramMessageCommand command)
    {
        var isTargetLangugeSetted = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == command.UserId && x.TargetLanguageId != null);
        if (!isTargetLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.TargetLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false, command.Update);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        var isNativeLangugeSetted = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == command.UserId && x.NativeLanguageId != null);
        if (!isNativeLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.NativeLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false, command.Update);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        return true;
    }

    public async Task<bool> ValidateThatAudioLanguageSelected(BaseTelegramMessageCommand command)
    {
        var isAudioLangugeSetted = await repositoryUserSettings.GetAnyAsync(x => x.TelegramUserId == command.UserId && x.AudioLanguageId != null);
        if (!isAudioLangugeSetted)
        {
            var menuCommand = menuConfig.Value.Commands.First(x => x.Id == BotMenuId.AudioTranscriptionLanguage);
            var commandToChangeLanguage = new HandleMenuCommand(menuCommand, command.ChatId, command.MessageId, command.UserId, false, command.Update);
            await commandDispatcher.DispatchAsync(commandToChangeLanguage);
            return false;
        }

        return true;
    }
}
