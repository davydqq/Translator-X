using HtmlAgilityPack;
using System.Text.RegularExpressions;
using TB.Meaning.Entities;

namespace TB.Meaning;

public class CambridgeDictionaryService
{
    const string baseUrl = "https://dictionary.cambridge.org/";

    const string dictionaryUrl = $"dictionary/english";

    const string spellCheckUrl = $"spellcheck/english";

    private readonly HttpClient _httpClient;

    public CambridgeDictionaryService(HttpClient httpClient)
    {
        this._httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<MeaningResult> GetCambridgeEnglishAsync(string phrase)
    {
        var res = new List<MeaningPhraseResult>();
        phrase = phrase.Trim();


        var infoPhrase = phrase.Replace(" ", "-");
        var meaning = await GetPhraseInfo(infoPhrase);

        if(meaning != null)
        {
            res.Add(new MeaningPhraseResult(phrase, meaning));
            return new MeaningResult { IsMatched = true, Results = res };
        }

        var meanings = await GetSpellCheckPhrases(phrase);

        if (meanings != null)
        {
            meanings = ClearArray(meanings);

            var fullMatchPhrase = meanings.FirstOrDefault(x => x == phrase);

            if (fullMatchPhrase != null)
            {
                var desc = await GetPhraseInfo(fullMatchPhrase);
                res.Add(new MeaningPhraseResult(fullMatchPhrase, desc));
            }
            else
            {
                var firstNumber = 5;

                var firstMeanings = meanings.Take(firstNumber);

                foreach (var str in firstMeanings)
                {
                    await ProcessPhraseInfo(res, str);
                }

                var splitPhrase = phrase.Split(" ");
                var otherMeanings = meanings.Skip(firstNumber).Take(5);

                if (otherMeanings.Any())
                {
                    foreach (var splitWord in splitPhrase)
                    {
                        var wordMeaning = otherMeanings.FirstOrDefault(x => x == splitWord);
                        await ProcessPhraseInfo(res, wordMeaning);
                    }
                }
            }

            return new MeaningResult { IsMatched = false, Results = res }; ;
        }

        return null;
    }

    private async Task ProcessPhraseInfo(List<MeaningPhraseResult> res, string str)
    {
        if (string.IsNullOrEmpty(str)) return;

        var desc = await GetPhraseInfo(str);

        if (!string.IsNullOrEmpty(desc))
        {
            desc = ClearSTR(desc);
            if (!string.IsNullOrEmpty(desc))
            {
                res.Add(new MeaningPhraseResult(str, desc));
            }
        }
    } 

    async Task<IEnumerable<string>> GetSpellCheckPhrases(string phrase)
    {
        var resp = await _httpClient.GetAsync(spellCheckUrl + "/?q=" + phrase);

        if (resp.IsSuccessStatusCode)
        {
            var html = await resp.Content.ReadAsStringAsync();

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(html);

            var node = htmlSnippet.DocumentNode.SelectSingleNode("//h1[@class='lpb-10 lbb']");
            if(node != null && node.InnerText.Contains("Your search terms did not match any entries"))
            {
                return null;
            }

            var nodes = htmlSnippet.DocumentNode.SelectNodes("//li[@class='lbt lp-5 lpl-20']");

            return nodes.Where(x => x != null && !string.IsNullOrEmpty(x.InnerText)).Select(x => x.InnerText);
        }

        return null;
    }

    async Task<string> GetPhraseInfo(string phrase)
    {
        var resp = await _httpClient.GetAsync(dictionaryUrl + "/" + phrase);

        if (resp.IsSuccessStatusCode)
        {
            var html = await resp.Content.ReadAsStringAsync();

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(html);

            var descriptionNode = htmlSnippet.DocumentNode.SelectSingleNode("//div[@class='def ddef_d db']");

            if (descriptionNode != null)
            {
                return descriptionNode.InnerText;
            }
        }

        return null;
    }

    private string ClearSTR(string str) => Regex.Replace(str, @"\t|\n|\r|→", "").Trim();

    IEnumerable<string> ClearArray(IEnumerable<string> strs)
    {
        return strs.Select(x => ClearSTR(x)).Where(x => x?.Length > 2);
    }
}
