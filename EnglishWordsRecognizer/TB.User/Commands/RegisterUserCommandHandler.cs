using CQRS.Commands;
using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.User.Commands;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IRepository<TelegramUser, int> repository;

    public RegisterUserCommandHandler(IRepository<TelegramUser, int> repository)
    {
        this.repository = repository;
    }

    public async Task HandleAsync(RegisterUserCommand command, CancellationToken cancellation = default)
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
                Username = user.Username
            };

            var isUserExist = await repository.GetAnyAsync(x => x.TelegramUserId == user.Id);
            if (!isUserExist)
            {
                await repository.AddAsync(dbUser);
            }
        }
    }
}
