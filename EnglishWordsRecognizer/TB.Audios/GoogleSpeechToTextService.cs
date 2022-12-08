using Google.Cloud.Speech.V1;
using Microsoft.Extensions.Options;
using TB.Audios.Entities;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace TB.Audios;

public class GoogleSpeechToTextService : ISpeechToTextService
{
    private readonly IOptions<GoogleConfig> options;

    public GoogleSpeechToTextService(IOptions<GoogleConfig> options)
    {
        this.options = options;
    }

    public async Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes)
    {
        RecognitionAudio audio = RecognitionAudio.FromBytes(bytes);

        var builder = new SpeechClientBuilder() { CredentialsPath = options.Value.Path };

        var client = await builder.BuildAsync();

        RecognitionConfig config = new RecognitionConfig
        {
            Encoding = AudioEncoding.EncodingUnspecified,
            SampleRateHertz = 16000,
            LanguageCode = LanguageCodes.English.UnitedStates,
        };

        RecognizeResponse response = await client.RecognizeAsync(config, audio);

        return new AudioRecognizeResponse
        {
            ProcessedSeconds = response.TotalBilledTime.Seconds,
            Results = response.Results.Select(x => new AudioRecognizeResult
            {
                LanguageCode = x.LanguageCode,
                Tag = x.ChannelTag,
                EndTime = x.ResultEndTime.ToTimeSpan(),
                Alternatives = x.Alternatives.Select(q => new AudioTranslate
                {
                    Confidence = q.Confidence,
                    Transcript = q.Transcript,
                    Words = q.Words.Select(v => new AudioWord
                    {
                        SpeakerTag = v.SpeakerTag,
                        StartTime = v.StartTime.ToTimeSpan(),
                        EndTime = v.EndTime.ToTimeSpan(),
                        Confidence = v.Confidence,
                        Word = v.Word
                    }).ToList()
                }).ToList()
            }).ToList()
        };
    }
}
