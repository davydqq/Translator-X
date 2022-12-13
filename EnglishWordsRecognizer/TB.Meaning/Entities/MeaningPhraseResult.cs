
namespace TB.Meaning.Entities;

public class MeaningPhraseResult
{
    public string Phrase { set; get; }

    public string Meaning { set; get; }

    public MeaningPhraseResult(string phrase, string meaning)
    {
        Phrase = phrase;
        Meaning = meaning;
    }
}
