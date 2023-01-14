using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.BillingPlans;
using TB.Common;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.SpeechToText.Commands;
using TB.SpeechToText.Entities;
using TB.User;
using Telegram.Bot.Types.Enums;
namespace TB.Audios.Commands;

public class HandleAudiosCommandHandler : ICommandHandler<HandleAudiosCommand, bool>
{
    private readonly ILogger<HandleAudiosCommandHandler> logger;
    private readonly IUserService userService;
    private readonly IQueryDispatcher queryDispatcher;
    private readonly UserSettingsRepository userSettingsRepository;
    private readonly ILocalizationService localizationService;
    private readonly ICommandDispatcher commandDispatcher;
    private readonly IBillingPlanService billingPlanService;
    private readonly string[] supportedAudioFormats = AudiosFormats.GetFormats();

    public HandleAudiosCommandHandler(
        ILogger<HandleAudiosCommandHandler> logger,
        IUserService userService,
        IQueryDispatcher queryDispatcher,
        UserSettingsRepository userSettingsRepository,
        ILocalizationService localizationService,
        ICommandDispatcher commandDispatcher,
        IBillingPlanService billingPlanService)
    {
        this.logger = logger;
        this.userService = userService;
        this.queryDispatcher = queryDispatcher;
        this.userSettingsRepository = userSettingsRepository;
        this.localizationService = localizationService;
        this.commandDispatcher = commandDispatcher;
        this.billingPlanService = billingPlanService;
    }

    public async Task<bool> HandleAsync(HandleAudiosCommand command, CancellationToken cancellation = default)
    {
        var res = await userService.ValidateThatUserSelectLanguages(command);
        if (!res) return false;

        var res2 = await userService.ValidateThatAudioLanguageSelected(command);
        if (!res2) return false;

        var isCanProcessRequest = await billingPlanService.IsCanProcessAudioAsync(command.UserId);
        if (!isCanProcessRequest)
        {
            var text = await localizationService.GetTranslateByInterface("billing.exceedLimit", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        // VALIDATIONS
        if (command.File.Duration > 59)
        {
            var text = await localizationService.GetTranslateByInterface("app.audio.noExceedDuration", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        if(!supportedAudioFormats.Any(x => x == command.File.MimeType))
        {
            var text = await localizationService.GetTranslateByInterface("app.audio.noSupportFormat", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        var processingMessage = await localizationService.GetTranslateByInterface("app.content.processing", command.UserId);
        var processesingMessageCommand = new SendMessageCommand(command.ChatId, processingMessage, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
        var processingMessageResult = await commandDispatcher.DispatchAsync(processesingMessageCommand);

        var downloadFile = await queryDispatcher.DispatchAsync(new DownloadFileQuery(command.File.FileId));

        var settings = await userSettingsRepository.GetAudioLanguageAsync(command.UserId);

        var commandToSend = new AudioToTextCommand(downloadFile.File, settings.AudioLanguageId.Value, command.File.MimeType, command.UserId);
        var result = await commandDispatcher.DispatchAsync(commandToSend);


        if (!result.IsSuccess)
        {
            var text = await localizationService.GetTranslateByInterface("app.audio.cantProcess", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        if (result.Results == null || result.Results.Count == 0)
        {
            var text = await localizationService.GetTranslateByInterface("app.audio.EmptyResult", command.UserId);
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return false;
        }

        var textProcessed = await ProcessSpeechToTextResult(result, command.UserId, settings.AudioLanguage);

        // DELETE PROCESSING MESSAGE
        await commandDispatcher.DispatchAsync(new DeleteMessageCommand(command.ChatId, processingMessageResult.MessageId));

        if (!string.IsNullOrEmpty(textProcessed))
        {
            textProcessed += "\n\n\n" + await localizationService.GetTranslateByInterface("app.audios.languageWarning", command.UserId);

            var commandTelegram = new SendMessageCommand(command.ChatId, textProcessed, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
        }

        return true;
    }

    private async Task<string> ProcessSpeechToTextResult(AudioRecognizeResponse response, long userId, Language audioLanguage)
    {
        var audioTranscriptionHeader = await localizationService.GetTranslateByInterface("app.audios.audioText", userId);

        var resText = $"<b>{audioTranscriptionHeader}</b>\n\n";
        resText += $"<b>{audioLanguage.GetCode().ToUpper()}</b>\n\n";
        foreach (var item in response.Results)
        {
            foreach (var translate in item.Alternatives)
            {
                resText += translate.Transcript + "\n";
            }
        }

        return resText;
    }
}
