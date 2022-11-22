using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBotTranslator.Entities;

namespace TelegramBotTranslator;

public class TextProcessService
{
    private readonly IOptions<AzureTranslatorConfig> options;

    private readonly IHttpClientFactory httpClientFactory;

    public TextProcessService(IOptions<AzureTranslatorConfig> options, IHttpClientFactory httpClientFactory)
    {
        this.options = options;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<List<AzureDetectLanguageResponse>> DetectLanguagesAsync(string textToDetect)
    {
        // Input and output languages are defined as parameters.
        string route = "/detect?api-version=3.0";
        object[] body = new object[] { new { Text = textToDetect } };
        var requestBody = JsonConvert.SerializeObject(body);

        return await SendRequestAsync<List<AzureDetectLanguageResponse>>(requestBody, route);
    }

    public async Task<List<AzureTranslateResponse>> ProcessTextAsync(string[] textToTranslate, params string[] languages)
    {
        // Input and output languages are defined as parameters.
        string route = "/translate?api-version=3.0" + string.Join("", languages.Select(lang => $"&to={lang}"));
        object[] body = new object[] { new { Text = textToTranslate } };
        var requestBody = JsonConvert.SerializeObject(body);

        return await SendRequestAsync<List<AzureTranslateResponse>>(requestBody, route);
    }

    private async Task<T> SendRequestAsync<T>(string? requestBody, string route)
    {
        using var httpClient = httpClientFactory.CreateClient();
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
        // Read response as a string.
        string result = await response.Content.ReadAsStringAsync();

        var res = JsonConvert.DeserializeObject<T>(result);

        return res;
    }
}
