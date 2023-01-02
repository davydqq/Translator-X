using CQRS.Commands;
using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.User.Commands;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, bool>
{
    private readonly IRepository<TelegramUser, int> userRepository;
    private readonly IRepository<UserSettings, int> settingsRepository;

    public RegisterUserCommandHandler(
        IRepository<TelegramUser, int> userRepository,
        IRepository<UserSettings, int> settingsRepository)
    {
        this.userRepository = userRepository;
        this.settingsRepository = settingsRepository;
    }

    public async Task<bool> HandleAsync(RegisterUserCommand command, CancellationToken cancellation = default)
    {
        var message = command.Update.Message;
        if (message != null && message.From != null)
        {
            var user = message.From;

            var dbUser = new TelegramUser 
            {
                TelegramUserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsBot = user.IsBot,
                LanguageCode = user.LanguageCode,
                Username = user.Username,
            };

            var isUserExist = await userRepository.GetAnyAsync(x => x.TelegramUserId == user.Id);
            if (!isUserExist)
            {
                await userRepository.AddAsync(dbUser);
            }

            var isSettingsExist = await settingsRepository.GetAnyAsync(x => x.TelegramUserId == user.Id);
            if (!isSettingsExist)
            {
                await settingsRepository.AddAsync(new UserSettings { TelegramUserId = user.Id, InterfaceLanguageId = LanguageENUM.English });
            }
        }

        return true;
    }
}
