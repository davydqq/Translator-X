using System.Collections.Concurrent;
using TelegramBotStorage.Languages;

namespace TelegramBotStorage;

public class MemoryStorage
{
    public ConcurrentDictionary<long, LanguageENUM> UserId_NativeLanguage { get; set; } = new();

    public ConcurrentDictionary<long, LanguageENUM> UserId_TargetLanguage { get; set; } = new();

    public ConcurrentDictionary<long, bool> UserId_LangugageSetted { get; set; } = new();

}
