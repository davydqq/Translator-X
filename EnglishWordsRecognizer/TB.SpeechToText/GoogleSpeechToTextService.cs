using Google.Cloud.Speech.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.Common;
using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.SpeechToText.Entities;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace TB.SpeechToText;

public class GoogleSpeechToTextService : ISpeechToTextService
{
    private readonly IOptions<GoogleConfig> options;

    private readonly ILogger<GoogleSpeechToTextService> logger;
    private readonly IConfiguration configuration;
    private readonly string[] languages = new string[]
    {
        LanguageCodes.Ukrainian.Ukraine,
        LanguageCodes.Russian.Russia,
        LanguageCodes.English.UnitedStates,
        LanguageCodes.Spanish.Spain,
        LanguageCodes.French.France,
        LanguageCodes.Japanese.Japan,
        LanguageCodes.ChineseMandarin.SimplifiedChina,
        LanguageCodes.Czech.CzechRepublic,
        LanguageCodes.Danish.Denmark,
        LanguageCodes.Hindi.India,
        LanguageCodes.Italian.Italy,
        LanguageCodes.Swedish.Sweden,
        LanguageCodes.German.Germany,
        LanguageCodes.Polish.Poland,
        LanguageCodes.Turkish.Turkey
    };

    public ApiTypeENUM ApiType => ApiTypeENUM.Google;

    public double Costs => APICosts.GoogleAudioTranscriptionSecondI;

    public GoogleSpeechToTextService(
        IOptions<GoogleConfig> options, 
        ILogger<GoogleSpeechToTextService> logger,
        IConfiguration configuration)
    {
        this.options = options;
        this.logger = logger;
        this.configuration = configuration;
    }

    public async Task<AudioRecognizeResponse> RecognizeAsync(byte[] bytes, LanguageENUM language, string mimeType)
    {
        RecognitionAudio audio = RecognitionAudio.FromBytes(bytes);

        var result = await RecognizeAsyncIternal(audio, language, mimeType);

        if (!result.isSuccess)
        {
            return new AudioRecognizeResponse();
        }

        var response = result.response;

        return new AudioRecognizeResponse
        {
            IsSuccess = true,
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

    private async Task<(bool isSuccess, RecognizeResponse response)> RecognizeAsyncIternal(RecognitionAudio audio, LanguageENUM language, string mimeType)
    {
        try
        {
            var builder = GetBuilder();

            var client = await builder.BuildAsync();

            RecognitionConfig config = new RecognitionConfig()
            {
                Encoding = GetEncoding(mimeType),
                SampleRateHertz = GetSampleRateHertz(mimeType),
                LanguageCode = GetAudioLanguage(language),
            };

            RecognizeResponse response = await client.RecognizeAsync(config, audio);

            return (true, response);

        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
            return (false, null);
        }
    }

    private SpeechClientBuilder GetBuilder()
    {
        var envVariables = configuration["GOOGLE_APPLICATION_CREDENTIALS"];
        if(envVariables != null)
        {
            return new SpeechClientBuilder() { JsonCredentials = envVariables, };
        }

        return new SpeechClientBuilder() { CredentialsPath = options.Value.Path };
    }

    private int GetSampleRateHertz(string mimeType)
    {
        switch (mimeType)
        {
            case AudiosFormats.Flac:
                {
                    return 0;
                }
            case AudiosFormats.WAV:
                {
                    return 0;
                }
            case AudiosFormats.X_WAV:
                {
                    return 0;
                }
            case AudiosFormats.OGG:
                {
                    return 48000;
                }
            default:
                {
                    return 16000;
                }
        }
    }

    private AudioEncoding GetEncoding(string mimeType)
    {
        switch (mimeType)
        {
            case AudiosFormats.Flac:
                {
                    return AudioEncoding.Flac;
                }
            case AudiosFormats.WAV:
                {
                    return AudioEncoding.Linear16;
                }
            case AudiosFormats.X_WAV:
                {
                    return AudioEncoding.Linear16;
                }
            case AudiosFormats.OGG:
                {
                    return AudioEncoding.OggOpus;
                }
            default:
                {
                    return AudioEncoding.EncodingUnspecified;
                }
        }
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
