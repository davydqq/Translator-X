using CQRS.Commands;
using Microsoft.Extensions.Logging;
using TB.Audios.Commands;
using TB.Common;
using TB.Core.Commands;
using TB.Images.Commands;
using TB.Localization.Services;
using TB.Texts.Commands;
using Telegram.Bot.Types.Enums;

namespace TB.Replies.Commands;

public class HandleRepliesCommandHandler : ICommandHandler<HandleRepliesCommand, bool>
{
    private readonly ILogger<HandleRepliesCommandHandler> logger;
    private readonly ICommandDispatcher commandDispatcher;
    private readonly ILocalizationService localizationService;

    public HandleRepliesCommandHandler(
        ILogger<HandleRepliesCommandHandler> logger,
        ICommandDispatcher commandDispatcher,
        ILocalizationService localizationService)
    {
        this.logger = logger;
        this.commandDispatcher = commandDispatcher;
        this.localizationService = localizationService;
    }

    public async Task<bool> HandleAsync(HandleRepliesCommand command, CancellationToken cancellation = default)
    {
        ICommand<bool> commandToSend = null;

        var replyMessageId = command.ReplyMessage.MessageId;

        if (command.ReplyMessage.Type == MessageType.Text)
        {
            commandToSend = new HandleTextsCommand(command.ChatId, command.UserId, replyMessageId, command.ReplyMessage.Text, replyMessageId);
        }
        else if (command.ReplyMessage.Type == MessageType.Sticker)
        {
            var files = new List<ImagesInfo>
            {
                new ImagesInfo(command.ReplyMessage.Sticker.FileId, command.ReplyMessage.Sticker.FileSize)
            };
            commandToSend = new HandleImagesCommand(command.ChatId, command.UserId, replyMessageId, command.ReplyMessage.Caption, files);
        }
        else if (TelegramMessageContentHelper.IsPhotoRoute(command.ReplyMessage))
        {
            var files = TelegramMessageContentHelper.GetPhotos(command.ReplyMessage);
            commandToSend = new HandleImagesCommand(command.ChatId, command.UserId, replyMessageId, command.ReplyMessage.Caption, files);
        }
        else if (TelegramMessageContentHelper.IsAudioRoute(command.ReplyMessage))
        {
            var file = TelegramMessageContentHelper.GetAudio(command.ReplyMessage);
            commandToSend = new HandleAudiosCommand(command.ChatId, command.UserId, replyMessageId, file);
        }

        if(commandToSend == null)
        {
            var text = await localizationService.GetTranslateByInterface("app.file.noSupportContent", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: replyMessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        await commandDispatcher.DispatchAsync(commandToSend);

        return true;
    }
}
