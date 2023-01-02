using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Core.Commands;
using TB.Localization.Services;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TB.Videos.Commands;

public class HandleVideosCommandHandler : ICommandHandler<HandleVideosCommand>
{
    private readonly ILogger<HandleVideosCommandHandler> logger;
    private readonly ICommandDispatcher commandDispatcher;
    private readonly ILocalizationService localizationService;

    public HandleVideosCommandHandler(
        ILogger<HandleVideosCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        ILocalizationService localizationService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.localizationService = localizationService;
    }

    public async Task HandleAsync(HandleVideosCommand command, CancellationToken cancellation = default)
    {
        var text = await localizationService.GetTranslateByInterface("app.file.noSupportContent", command.UserId);
        var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
        await commandDispatcher.DispatchAsync(commandTelegram);
    }
}
