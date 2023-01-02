using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Core.Commands;
using TB.Localization.Services;
using Telegram.Bot.Types.Enums;

namespace TB.Documents.Commands;

public class HandleDocumentsCommandHandler : ICommandHandler<HandleDocumentsCommand>
{
    private readonly ILogger<HandleDocumentsCommandHandler> logger;

    private readonly ICommandDispatcher commandDispatcher;

    private readonly ILocalizationService localizationService;

    public HandleDocumentsCommandHandler(
        ILogger<HandleDocumentsCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        ILocalizationService localizationService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.localizationService = localizationService;
    }

    public async Task HandleAsync(HandleDocumentsCommand command, CancellationToken cancellation = default)
    {
        var text = await localizationService.GetTranslateByInterface("app.file.noSupportContent", command.UserId);
        var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
        await commandDispatcher.DispatchAsync(commandTelegram);
    }
}
