using HtmlAgilityPack;

namespace TB.Meaning;

public class ThesaurusService
{
    const string baseUrl = "https://www.thesaurus.com/";

    private readonly HttpClient _httpClient;

    public ThesaurusService(HttpClient httpClient)
    {
        this._httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<IEnumerable<string>> GetSynonymsAsync(string str)
    {
        if (string.IsNullOrEmpty(str)) return null;

        var resp = await _httpClient.GetAsync($"browse/{str}");

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
