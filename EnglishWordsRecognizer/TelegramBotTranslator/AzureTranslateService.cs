using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using TB.Database.Entities.Requests;
using TB.Translator.Entities;
using TB.Translator.Entities.Azure;

namespace TB.Translator;

public class AzureTranslateService : ITranslateService
{
    private readonly IOptions<AzureTranslatorConfig> options;

    private readonly IHttpClientFactory httpClientFactory;

    public AzureTranslateService(IOptions<AzureTranslatorConfig> options, IHttpClientFactory httpClientFactory)
    {
        this.options = options;
        this.httpClientFactory = httpClientFactory;
    }

    public ApiTypeENUM apiTypeENUM => ApiTypeENUM.Azure;

    public async Task<List<DetectLanguageResponse>> DetectLanguagesAsync(params string[] textToDetect)
    {
        // Input and output languages are defined as parameters.
        string route = "/detect?api-version=3.0";
        object[] body = textToDetect.Select(x => new AzureRequestBody { Text = x }).ToArray();
        var requestBody = JsonConvert.SerializeObject(body);

        var resp = await SendRequestAsync<List<AzureDetectLanguageResponse>>(requestBody, route);

        if (resp == null) return null;

        return resp.Select(x => new DetectLanguageResponse
        {
            Language = x.Language,
            IsTranslationSupported = x.IsTranslationSupported,
            IsTransliterationSupported = x.IsTransliterationSupported,
            Score = x.Score,

        }).ToList();
    }

    public async Task<List<TranslateResponse>> TranslateTextsAsync(string[] textToTranslate, params string[] languages)
    {
        // Input and output languages are defined as parameters.
        string route = "/translate?api-version=3.0" + string.Join("", languages.Select(lang => $"&to={lang}"));

        var texts = textToTranslate.Select(x => new AzureRequestBody { Text = x }).ToArray();
        object[] body = texts;
        var requestBody = JsonConvert.SerializeObject(body);

        var resp = await SendRequestAsync<List<AzureTranslateResponse>>(requestBody, route);

        if (resp == null) return null;

        return resp.Select(x => new TranslateResponse
        {
            DetectedLanguage = new DetectLanguage
            {
                Language = x.DetectedLanguage.Language,
                Score = x.DetectedLanguage.Score
            },
            Translations = x.Translations.Select(q => new Translate
            {
                Text = q.Text,
                To = q.To
            }).ToList()
        }).ToList();
    }

    private async Task<T> SendRequestAsync<T>(string? requestBody, string route)
    {
        using var httpClient = httpClientFactory.CreateClient("AzureTranslator");
        using var request = new HttpRequestMessage();

        // Build the request.
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(options.Value.Endpoint + route);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", options.Value.Key);
        // location required if you're using a multi-service or regional (not global) resource.
        request.Headers.Add("Ocp-Apim-Subscription-Region", options.Value.Location);

        // Send the request and get response.
        HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode) return default(T)!;

        // Read response as a string.
        string result = await response.Content.ReadAsStringAsync();

        var res = JsonConvert.DeserializeObject<T>(result);

        return res;
    }
}
