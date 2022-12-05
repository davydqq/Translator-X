using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Options;
using TB.Audios.Entities;

namespace TB.Audios;

public class AzureSpechToTextService : ISpeechToTextService
{
    private readonly IOptions<AzureSpeechConfig> speechConfig;

    public AzureSpechToTextService(IOptions<AzureSpeechConfig> speechConfig)
    {
        this.speechConfig = speechConfig;
    }

    public async Task Test()
    {
        var config = SpeechConfig.FromSubscription(speechConfig.Value.Key, speechConfig.Value.Location);

        using var speechRecognizer = new SpeechRecognizer(config);
        // speechRecognizer.re
    }
}
