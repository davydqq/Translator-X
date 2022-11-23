using CQRS.Commands;

namespace TelegramBotCommands;

public class TelegramUpdatesHandler : ICommandHandler<TelegramUpdatesCommand>
{
    public Task HandleAsync(TelegramUpdatesCommand command, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}
