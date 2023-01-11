using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.SpeechToText.Entities;

namespace TB.SpeechToText.Commands;

public class AudioToTextCommandHandler : ICommandHandler<AudioToTextCommand, AudioRecognizeResponse>
{
    private readonly ILogger<AudioToTextCommandHandler> logger;

    private readonly ISpeechToTextService speechToTextService;

    private readonly IRepository<AudioRequest, int> audioRequestRepository;

    public AudioToTextCommandHandler(
        ILogger<AudioToTextCommandHandler> logger,
        ISpeechToTextService speechToTextService,
        IRepository<AudioRequest, int> audioRequestRepository)
    {
        this.logger = logger;
        this.speechToTextService = speechToTextService;
        this.audioRequestRepository = audioRequestRepository;
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

        var request = new AudioRequest(speechToTextService.ApiType, command.UserId);

        var results = await speechToTextService.RecognizeAsync(command.Bytes, command.Language, command.MimeType);

        request.InitTranscription(results.ProcessedSeconds, Costs.GoogleAudioTranscriptionSecond);
        request.InitResponse(JsonConvert.SerializeObject(results), results.IsSuccess);
        await audioRequestRepository.AddAsync(request);

        return results;
    }
}
