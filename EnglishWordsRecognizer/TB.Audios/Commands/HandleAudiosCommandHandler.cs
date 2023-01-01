using CQRS.Commands;
using CQRS.Queries;
using Microsoft.Extensions.Logging;
using TB.Audios.Entities;
using TB.Core.Commands;
using TB.Core.Queries;
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
        var res = await userService.ValidateThatUserSelectLanguages(command);
        var res2 = await userService.ValidateThatAudioLanguageSelected(command);

        if (res && res2)
        {
            var bytes = await queryDispatcher.DispatchAsync(new DownloadFileQuery(command.File.FileId));

            var settings = await userSettingsRepository.GetSettingsIncludeTargetNativeLanguagesAsync(command.UserId);
 
            var result = await speechToTextService.RecognizeAsync(bytes, settings.AudioLanguageId.Value);

            if (result != null && result.Results != null && result.Results.Count > 0)
            {
                // TODO IMPROVE OUTPUT AUDIO
                var text = await ProcessSpeechToTextResult(result, command.UserId);

                if (!string.IsNullOrEmpty(text))
                {
                    var commandTelegram = new SendMessageCommand(command.ChatId, text, parseMode: ParseMode.Html, replyToMessageId: command.MessageId);
                    await commandDispatcher.DispatchAsync(commandTelegram);
                }
            }
        }
    }

    private async Task<string> ProcessSpeechToTextResult(AudioRecognizeResponse response, long userId)
    {
        var audioTranscriptionHeader = await localizationService.GetTranslateByInterface("app.audios.audioText", userId);

        var resText = $"<b>{audioTranscriptionHeader}</b>\n\n";
        foreach(var item in response.Results)
        {
            foreach(var translate in item.Alternatives)
            {
                resText += translate.Transcript + "\n";
            }
        }

        return resText;
    }
}
