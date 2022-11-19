using TelegramBotStorage.Languages;

namespace TelegramBotStorage;

public static class SupportedLanguages
{
    public const string Ukrainian = @"Ukrainian 🇺🇦";

    public const string Russian = @"Russian 🇷🇺";

    public const string English = @"English 🇺🇸";

    public const string Spanish = @"Spanish 🇪🇸";

    public const string French = @"French 🇫🇷";

    public const string Japanese = @"Japanese 🇯🇵";

    public const string Chinese = @"Chinese 🇨🇳";

    public const string Czech = @"Czech 🇨🇿";

    public const string Danish = @"Danish 🇩🇰";

    public const string Hindi = @"Hindi 🇮🇳";

    public const string Italian = @"Italian 🇮🇹";

    public const string Swedish = @"Swedish 🇸🇪";

    public const string German = @"German 🇩🇪";

    public const string Polish = @"Polish 🇵🇱";

    public const string Turkish = @"Turkish 🇹🇷";

    public static List<Language> languages = null;

    public static Dictionary<LanguageENUM, Language> languagesDict = null;

    public static List<Language> GetLanguages()
    {
        if (languages == null)
        {
            languages = new List<Language>
            {
                new Language(LanguageENUM.Ukrainian, Ukrainian),
                new Language(LanguageENUM.Russian, Russian),
                new Language(LanguageENUM.English, English),
                new Language(LanguageENUM.Spanish, Spanish),
                new Language(LanguageENUM.French, French),
                new Language(LanguageENUM.Japanese, Japanese),
                new Language(LanguageENUM.Chinese, Chinese),
                new Language(LanguageENUM.Czech, Czech),
                new Language(LanguageENUM.Danish, Danish),
                new Language(LanguageENUM.Hindi, Hindi),
                new Language(LanguageENUM.Italian, Italian),
                new Language(LanguageENUM.Swedish, Swedish),
                new Language(LanguageENUM.German, German),
                new Language(LanguageENUM.Polish, Polish),
                new Language(LanguageENUM.Turkish, Turkish),
            };

            languagesDict = languages.ToDictionary(X => X.Id);
        }

        return languages;
    }
}
