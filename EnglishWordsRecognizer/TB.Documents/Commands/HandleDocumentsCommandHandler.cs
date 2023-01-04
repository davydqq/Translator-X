using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Audios.Commands;
using TB.Common;
using TB.Core.Commands;
using TB.Images.Commands;
using TB.Localization.Services;
using Telegram.Bot.Types.Enums;

namespace TB.Documents.Commands;

public class HandleDocumentsCommandHandler : ICommandHandler<HandleDocumentsCommand, bool>
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

    public async Task<bool> HandleAsync(HandleDocumentsCommand command, CancellationToken cancellation = default)
    {
        if (TelegramMessageContentHelper.isDocumentAudioFile(command.Update.Message!))
        {
            var file = TelegramMessageContentHelper.GetAudio(command.Update.Message!);
            var audioCommand = new HandleAudiosCommand(command.ChatId, command.UserId, command.MessageId, file, command.Update);
            await commandDispatcher.DispatchAsync(audioCommand);
            return true;
        }

        if (TelegramMessageContentHelper.isDocumentPhotoFile(command.Update.Message!))
        {
            var files = TelegramMessageContentHelper.GetPhotos(command.Update.Message!);
            var photoCommand = new HandleImagesCommand(command.ChatId, command.UserId, command.MessageId, command.Update.Message.Caption, files, command.Update);
            await commandDispatcher.DispatchAsync(photoCommand);
            return true;
        }

        var text = await localizationService.GetTranslateByInterface("app.file.noSupportContent", command.UserId);
        var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
        await commandDispatcher.DispatchAsync(commandTelegram);

        return true;
    }
}
