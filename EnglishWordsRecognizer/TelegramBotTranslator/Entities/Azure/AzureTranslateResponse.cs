namespace TB.Translator.Entities.Azure;

public class AzureTranslateResponse
{
    public List<AzureTranslate> Translations { set; get; }

    public AzureDetectLanguage DetectedLanguage { set; get; }
}

public class AzureDetectLanguage
{
    public string Language { get; set; }

    public double Score { set; get; }
}


public class AzureTranslate
{
    public string Text { set; get; }

    public string To { set; get; }
}
