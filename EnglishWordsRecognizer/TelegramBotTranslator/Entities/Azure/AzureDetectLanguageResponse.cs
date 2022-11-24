namespace TB.Translator.Entities.Azure;

public class AzureDetectLanguageResponse
{
    public string Language { set; get; }

    public double Score { set; get; }

    public bool IsTranslationSupported { set; get; }

    public bool IsTransliterationSupported { set; get; }
}
