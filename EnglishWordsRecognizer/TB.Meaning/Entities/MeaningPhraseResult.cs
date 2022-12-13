
namespace TB.Meaning.Entities;

public class MeaningPhraseResult
{
    public string Phrase { set; get; }

    public string Meaning { set; get; }

    public MeaningPhraseResult(string phrase, string meaning)
    {
        Phrase = phrase;
        Meaning = ClearMeaning(meaning);
    }

    private string ClearMeaning(string meaning)
    {
        if (!string.IsNullOrEmpty(meaning) && meaning.Trim().EndsWith(":"))
        {
            meaning = meaning.Trim();
            return meaning.Substring(0, meaning.Length - 1);
        }

        return meaning;
    }
}
