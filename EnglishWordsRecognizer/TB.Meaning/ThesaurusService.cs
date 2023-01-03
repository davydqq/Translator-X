using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB.Meaning;

public class ThesaurusService
{
    const string baseUrl = "https://www.thesaurus.com";

    private readonly IHttpClientFactory httpClientFactory;

    public ThesaurusService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<string>> GetSynonymsAsync(string str)
    {
        if (string.IsNullOrEmpty(str)) return null;

        using var httpClient = httpClientFactory.CreateClient();
        var resp = await httpClient.GetAsync(baseUrl + $"/browse/{str}");

        if(!resp.IsSuccessStatusCode) return null;

        var html = await resp.Content.ReadAsStringAsync();

        HtmlDocument htmlSnippet = new HtmlDocument();
        htmlSnippet.LoadHtml(html);

        var nodes = htmlSnippet.DocumentNode.SelectSingleNode("//div[@id='meanings']").Descendants();
        if (nodes != null && nodes.Count() > 0)
        {
            var liNodes = nodes.Where(x => x.Name == "li");
            return liNodes.Where(x => x != null && !string.IsNullOrEmpty(x.InnerText)).Select(x => x.InnerText.Trim());
        }

        return null;
    }
}
