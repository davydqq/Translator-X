using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.SpeechToText.Entities;

namespace TB.SpeechToText.Commands;

public class AudioToTextCommandHandler : ICommandHandler<AudioToTextCommand, AudioRecognizeResponse>
{
    private readonly ILogger<AudioToTextCommandHandler> logger;

    private readonly ISpeechToTextService speechToTextService;

    private readonly AudioRequestRepository audioRequestRepository;

    private readonly UserPlansRepository userPlansRepository;

    public AudioToTextCommandHandler(
        ILogger<AudioToTextCommandHandler> logger,
        ISpeechToTextService speechToTextService,
        AudioRequestRepository audioRequestRepository,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.speechToTextService = speechToTextService;
        this.audioRequestRepository = audioRequestRepository;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<AudioRecognizeResponse> HandleAsync(AudioToTextCommand command, CancellationToken cancellation = default)
    {
        // VALIDATION
        // TODO
        if (command.Bytes == null || command.Bytes.Length == 0)
        {
            logger.LogError("Bytes null");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);
        var request = new AudioRequest(speechToTextService.ApiType, command.UserId, plan.Id);

        var results = await speechToTextService.RecognizeAsync(command.Bytes, command.Language, command.MimeType);

        request.InitTranscription(results.ProcessedSeconds, Costs.GoogleAudioTranscriptionSecond);
        request.InitResponse(JsonConvert.SerializeObject(results), results.IsSuccess);
        await audioRequestRepository.AddAsync(request);

        return results;
    }
}
