// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using System.Text.RegularExpressions;

string baseUrl = "https://dictionary.cambridge.org";
 
string dictionaryUrl = $"{baseUrl}/dictionary/english";

string spellCheckUrl = $"{baseUrl}/spellcheck/english";

using var httpClient = new HttpClient();

var phrase = "moron".Trim();

var resp = await GetPhraseInfo(phrase);
Console.WriteLine(resp);

/*
var meanings = await GetSpellCheckPhrases(phrase);

meanings = ClearArray(meanings);

if (meanings != null)
{
    var fullMatchPhrase = meanings.FirstOrDefault(x => x == phrase);

    if (fullMatchPhrase != null)
    {
        Console.WriteLine("Fullmatch Phrase: " + fullMatchPhrase);
        var desc = await GetPhraseInfo(fullMatchPhrase);
        Console.WriteLine("Description: " + desc);
    }
    else
    {
        var firstNumber = 2;

        var firstMeanings = meanings.Take(firstNumber);

        foreach (var str in firstMeanings)
        {
            Console.WriteLine("Phrase: " + str);
            var desc = await GetPhraseInfo(str);
            Console.WriteLine("Description: " + desc);
        }

        var splitPhrase = phrase.Split(" ");
        var otherMeanings = meanings.Skip(firstNumber);

        if (otherMeanings.Any())
        {
            foreach (var splitWord in splitPhrase)
            {
                var wordMeaning = otherMeanings.FirstOrDefault(x => x == splitWord);
                if(wordMeaning != null)
                {
                    Console.WriteLine("Phrase: " + splitWord);
                    var desc = await GetPhraseInfo(wordMeaning);
                    Console.WriteLine("Description: " + desc);
                }
            }
        }
    }

    foreach (var str in meanings)
    {
        Console.WriteLine("Phrase: " + str);
        var desc = await GetPhraseInfo(str);
        Console.WriteLine("Description: " + desc);
        if(str == phrase)
        {
            break;
        }
    }
}
*/

async Task<string> GetPhraseInfo(string phrase)
{
    var resp = await httpClient.GetAsync(dictionaryUrl + "/" + phrase);

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

IEnumerable<string> ClearArray(IEnumerable<string> strs)
{
    return strs.Select(x =>
    {
        var v = Regex.Replace(x, @"\t|\n|\r", "");
        return v.Trim();
    });
}

async Task<IEnumerable<string>> GetSpellCheckPhrases(string phrase)
{
    var resp = await httpClient.GetAsync(spellCheckUrl + "/?q=" + phrase);

    if (resp.IsSuccessStatusCode)
    {
        var html = await resp.Content.ReadAsStringAsync();

        HtmlDocument htmlSnippet = new HtmlDocument();
        htmlSnippet.LoadHtml(html);

        var nodes = htmlSnippet.DocumentNode.SelectNodes("//li[@class='lbt lp-5 lpl-20']");

        return nodes.Where(x => x != null && !string.IsNullOrEmpty(x.InnerText)).Select(x => x.InnerText);
    }

    return null;
}