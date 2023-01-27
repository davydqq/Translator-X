using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TB.Common;
using TB.Database.Entities;
using TB.Database.Entities.Requests;
using TB.Translator.Entities;

namespace TB.Translator;

public class GoogleTranslateService : ITranslateService
{
    private readonly IConfiguration configuration;

    private readonly IOptions<GoogleConfig> options;

    private TranslationClient client;

    public GoogleTranslateService(IConfiguration configuration, IOptions<GoogleConfig> options)
    {
        this.configuration = configuration;
        this.options = options;
    }

    public ApiTypeENUM apiTypeENUM => ApiTypeENUM.Google;

    public double Costs => APICosts.GoogleCharTranslatePriceI;

    public async Task<List<DetectLanguageResponse>> DetectLanguagesAsync(string[] textToDetect)
    {
        var client = await GetClientAsync();

        var resp = await client.DetectLanguagesAsync(textToDetect.AsEnumerable());

        if (resp == null) return null;

        return resp.Select(x => new DetectLanguageResponse
        {
            Language = x.Language,
            IsTranslationSupported = true,
            IsTransliterationSupported = false,
            Score = x.Confidence,

        }).ToList();
    }

    public async Task<List<TranslateResponse>> TranslateTextsAsync(string[] textToTranslate, Database.Entities.Language languages)
    {
        var client = await GetClientAsync();

        var resp = await client.TranslateTextAsync(textToTranslate.AsEnumerable(), GetLanguage(languages.Id));

        if (resp == null || resp.Count == 0) return null;

        return resp.Select(x => new TranslateResponse
        {
            DetectedLanguage = new DetectLanguage
            {
                Language = x.DetectedSourceLanguage,
                Score = 0
            },
            Translations = new List<Translate> { new Translate { Text = x.TranslatedText, To = x.TargetLanguage } }
        }).ToList();
    }

    private async Task<TranslationClient> GetClientAsync()
    {
        var builder = GetBuilder();

        if (client == null)
        {
            client = await builder.BuildAsync();
        }

        return client;
    }

    private TranslationClientBuilder GetBuilder()
    {
        var envVariables = configuration["GOOGLE_APPLICATION_CREDENTIALS"];
        if (envVariables != null)
        {
            return new TranslationClientBuilder() { JsonCredentials = envVariables, };
        }

        return new TranslationClientBuilder() { CredentialsPath = options.Value.Path };
    }

    private string GetLanguage(LanguageENUM language)
    {
        switch (language)
        {
            case LanguageENUM.Ukrainian:
                {
                    return LanguageCodes.Ukrainian;
                }
            case LanguageENUM.Russian:
                {
                    return LanguageCodes.Russian;
                }
            case LanguageENUM.English:
                {
                    return LanguageCodes.English;
                }
            case LanguageENUM.Spanish:
                {
                    return LanguageCodes.Spanish;
                }
            case LanguageENUM.French:
                {
                    return LanguageCodes.French;
                }
            case LanguageENUM.Japanese:
                {
                    return LanguageCodes.Japanese;
                }
            case LanguageENUM.Chinese:
                {
                    return LanguageCodes.ChineseSimplified;
                }
            case LanguageENUM.Czech:
                {
                    return LanguageCodes.Czech;
                }
            case LanguageENUM.Danish:
                {
                    return LanguageCodes.Danish;
                }
            case LanguageENUM.Hindi:
                {
                    return LanguageCodes.Hindi;
                }
            case LanguageENUM.Italian:
                {
                    return LanguageCodes.Italian;
                }
            case LanguageENUM.Swedish:
                {
                    return LanguageCodes.Swedish;
                }
            case LanguageENUM.German:
                {
                    return LanguageCodes.German;
                }
            case LanguageENUM.Polish:
                {
                    return LanguageCodes.Polish;
                }
            case LanguageENUM.Turkish:
                {
                    return LanguageCodes.Turkish;
                }
            default: throw new Exception("Invalid language type");
        }
    }
}
