using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.Audios.Entities;
using TB.Core.Commands;
using TB.Core.Queries;
using TB.Database.Entities;
using TB.Database.Repositories;
using TB.Localization.Services;
using TB.User;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
namespace TB.Audios.Commands;

public class HandleAudiosCommandHandler : ICommandHandler<HandleAudiosCommand>
{
    private readonly ILogger<HandleAudiosCommandHandler> logger;
    private readonly IUserService userService;
    private readonly IQueryDispatcher queryDispatcher;
    private readonly ISpeechToTextService speechToTextService;
    private readonly UserSettingsRepository userSettingsRepository;
    private readonly ILocalizationService localizationService;
    private readonly ICommandDispatcher commandDispatcher;

    private readonly string[] supportedAudioFormats = new string[] 
    { 
        "audio/mpeg", 
        "audio/ogg", 
        "audio/wav", 
        "audio/webm",
        "audio/opus"
    };

    public HandleAudiosCommandHandler(
        ILogger<HandleAudiosCommandHandler> logger,
        IUserService userService,
        IQueryDispatcher queryDispatcher,
        ISpeechToTextService speechToTextService,
        UserSettingsRepository userSettingsRepository,
        ILocalizationService localizationService,
        ICommandDispatcher commandDispatcher)
    {
        this.logger = logger;
        this.userService = userService;
        this.queryDispatcher = queryDispatcher;
        this.speechToTextService = speechToTextService;
        this.userSettingsRepository = userSettingsRepository;
        this.localizationService = localizationService;
        this.commandDispatcher = commandDispatcher;
    }

    public async Task HandleAsync(HandleAudiosCommand command, CancellationToken cancellation = default)
    {
        // VALIDATIONS
        if(command.File.Duration > 59)
        {
            var text = "Audio duration must not exceed 60 seconds";
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return;
        }

        if(!supportedAudioFormats.Any(x => x == command.File.MimeType))
        {
            var text = "Not supported format. Use .mp3, .ogg, .opus, .wav, .webm";
            var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
            await commandDispatcher.DispatchAsync(commandTelegram);
            return;
        }

        var res = await userService.ValidateThatUserSelectLanguages(command);
        if (!res) return;

        var res2 = await userService.ValidateThatAudioLanguageSelected(command);
        if (!res2) return;

        // 
        var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(command.File.FileId));

        var settings = await userSettingsRepository.GetAudioLanguageAsync(command.UserId);

        var result = await speechToTextService.RecognizeAsync(bytes, settings.AudioLanguageId.Value);

        if (result != null && result.Results != null && result.Results.Count > 0)
        {
            // TODO IMPROVE OUTPUT AUDIO
            var text = await ProcessSpeechToTextResult(result, command.UserId, settings.AudioLanguage);

            if (!string.IsNullOrEmpty(text))
            {
                var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
                await commandDispatcher.DispatchAsync(commandTelegram);
            }
        }
    }

    private async Task<string> ProcessSpeechToTextResult(AudioRecognizeResponse response, long userId, Language audioLanguage)
    {
        var audioTranscriptionHeader = await localizationService.GetTranslateByInterface("app.audios.audioText", userId);

        var resText = $"<b>{audioTranscriptionHeader}</b>\n\n";
        resText += $"<b>{audioLanguage.GetCode().ToUpper()}</b>\n\n";
        foreach (var item in response.Results)
        {
            foreach(var translate in item.Alternatives)
            {
                resText += translate.Transcript + "\n";
            }
        }

        return resText;
    }
}
