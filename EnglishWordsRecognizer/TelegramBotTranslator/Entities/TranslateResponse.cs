namespace TB.Translator.Entities;

public class TranslateResponse
{
    public List<Translate> Translations { set; get; }

    public DetectLanguage DetectedLanguage { set; get; }
}

public class DetectLanguage
{
    public string Language { get; set; }

    public double Score { set; get; }
}


public class Translate
{
    public string Text { set; get; }

    public string To { set; get; }
}
