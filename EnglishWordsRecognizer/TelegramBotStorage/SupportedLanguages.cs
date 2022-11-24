using TB.MemoryStorage.Languages;
using TelegramBotStorage.Languages;

namespace TB.MemoryStorage;

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
                new Language(LanguageENUM.Ukrainian, Ukrainian, "uk"),
                new Language(LanguageENUM.Russian, Russian, "ru"),
                new Language(LanguageENUM.English, English, "en"),
                new Language(LanguageENUM.Spanish, Spanish, "es"),
                new Language(LanguageENUM.French, French, "fr"),
                new Language(LanguageENUM.Japanese, Japanese, "ja"),
                new Language(LanguageENUM.Chinese, Chinese, "zh-Hans"),
                new Language(LanguageENUM.Czech, Czech, "cs"),
                new Language(LanguageENUM.Danish, Danish, "da"),
                new Language(LanguageENUM.Hindi, Hindi, "hi"),
                new Language(LanguageENUM.Italian, Italian, "it"),
                new Language(LanguageENUM.Swedish, Swedish, "sv"),
                new Language(LanguageENUM.German, German, "de"),
                new Language(LanguageENUM.Polish, Polish, "pl"),
                new Language(LanguageENUM.Turkish, Turkish, "tr"),
            };

            languagesDict = languages.ToDictionary(X => X.Id);
        }

        return languages;
    }
}
