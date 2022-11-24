namespace TB.Translator.Entities;

public class DetectLanguageResponse
{
    public string Language { set; get; }

    public double Score { set; get; }

    public bool IsTranslationSupported { set; get; }

    public bool IsTransliterationSupported { set; get; }
}
