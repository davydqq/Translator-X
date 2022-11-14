using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotStorage.Languages;

namespace TelegramBotStorage;

public static class SupportedLanguages
{
    public const string Ukrainian = @"Ukrainian 🇺🇦";

    public const string Russian = @"Russian 🇷🇺";

    public static List<Language> languages = null;

    public static List<Language> GetLanguages()
    {
        if (languages == null)
        {
            languages = new List<Language>
            {
                new Language(LanguageENUM.Ukrainian, Ukrainian),
                new Language(LanguageENUM.Russian, Russian),
            };
        }

        return languages;
    }

    public static IEnumerable<InlineKeyboardButton> GetLanguagesButtons()
    {
        return GetLanguages().Select(language =>
        {
            var name = language.Name;
            var languageCallbackData = "LanguageId-" + language.Id.ToString();

            return InlineKeyboardButton.WithCallbackData(text: language.Name, callbackData: languageCallbackData);
        });
    }
}
