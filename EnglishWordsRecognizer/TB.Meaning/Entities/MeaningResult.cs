namespace TB.Meaning.Entities;

public class MeaningResult
{
    public bool IsMatched { set; get; }

    public IEnumerable<MeaningPhraseResult> Results { set; get; }
}
