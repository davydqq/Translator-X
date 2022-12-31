using Google.Cloud.Speech.V1;
using Microsoft.Extensions.Options;
using TB.Audios.Entities;
using TB.Database.Entities;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace TB.Audios;

public class GoogleSpeechToTextService : ISpeechToTextService
{
    private readonly IOptions<GoogleConfig> options;

    public GoogleSpeechToTextService(IOptions<GoogleConfig> options)
    {
        this.options = options;
    }

    public async Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes, LanguageENUM language)
    {
        RecognitionAudio audio = RecognitionAudio.FromBytes(bytes);

        var builder = new SpeechClientBuilder() { CredentialsPath = options.Value.Path };

        var client = await builder.BuildAsync();

        RecognitionConfig config = new RecognitionConfig
        {
            Encoding = AudioEncoding.EncodingUnspecified,
            SampleRateHertz = 16000,
            LanguageCode = GetAudioLanguage(language),
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
    
    private string GetAudioLanguage(LanguageENUM language)
    {
        switch (language)
        {
            case LanguageENUM.Ukrainian:
                {
                    return LanguageCodes.Ukrainian.Ukraine;
                }
            case LanguageENUM.Russian:
                {
                    return LanguageCodes.Russian.Russia;
                }
            case LanguageENUM.English:
                {
                    return LanguageCodes.English.UnitedStates;
                }
            case LanguageENUM.Spanish:
                {
                    return LanguageCodes.Spanish.Spain;
                }
            case LanguageENUM.French:
                {
                    return LanguageCodes.French.France;
                }
            case LanguageENUM.Japanese:
                {
                    return LanguageCodes.Japanese.Japan;
                }
            case LanguageENUM.Chinese:
                {
                    return LanguageCodes.ChineseMandarin.SimplifiedChina;
                }
            case LanguageENUM.Czech:
                {
                    return LanguageCodes.Czech.CzechRepublic;
                }
            case LanguageENUM.Danish:
                {
                    return LanguageCodes.Danish.Denmark;
                }
            case LanguageENUM.Hindi:
                {
                    return LanguageCodes.Hindi.India;
                }
            case LanguageENUM.Italian:
                {
                    return LanguageCodes.Italian.Italy;
                }
            case LanguageENUM.Swedish:
                {
                    return LanguageCodes.Swedish.Sweden;
                }
            case LanguageENUM.German:
                {
                    return LanguageCodes.German.Germany;
                }
            case LanguageENUM.Polish:
                {
                    return LanguageCodes.Polish.Poland;
                }
            case LanguageENUM.Turkish:
                {
                    return LanguageCodes.Turkish.Turkey;
                }
            default: throw new Exception("Invalid language type");
        }
    }
}
