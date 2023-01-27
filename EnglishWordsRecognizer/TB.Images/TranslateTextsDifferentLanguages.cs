using TB.Database.Entities;
using TB.Translator.Entities;

namespace TB.Images;

public class TranslateTextsDifferentLanguages
{
    public List<TranslateResponse> FirstTranslations { set; get; }
    public Language FirstLanguage { set; get; }


    public List<TranslateResponse> SecondTranslations { set; get; }
    public Language SecondLanguage { set; get; }

    public bool IsEmpty => FirstTranslations == null && SecondTranslations == null;

    public bool IsOneLanguage => FirstLanguage == null || SecondLanguage == null;

    public Language GetOneLanguage => FirstLanguage ?? SecondLanguage;

    public List<TranslateResponse> GetOneTranslations => FirstTranslations ?? SecondTranslations;
}
