using System.Collections.Concurrent;
using TelegramBotStorage.Languages;

namespace TelegramBotStorage;

public class MemoryStorage
{
    // user id, language id
    public ConcurrentDictionary<long, LanguageENUM> Storage { get; set; } = new(); 
}
