using System.Collections.Concurrent;
using TB.MemoryStorage.Languages;
using TelegramBotStorage.Languages;

namespace TB.MemoryStorage;

public class Storage
{
    public ConcurrentDictionary<long, LanguageENUM> UserId_NativeLanguage { get; set; } = new();

    public ConcurrentDictionary<long, LanguageENUM> UserId_TargetLanguage { get; set; } = new();

    public ConcurrentDictionary<long, bool> UserId_RecognizeMeaning { get; set; } = new();


    // ADD UPDATE
    public void AddOrUpdateUserNativeLanguage(long userId, LanguageENUM languageId)
    {
        UserId_NativeLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void AddOrUpdateUserTargetLanguage(long userId, LanguageENUM languageId)
    {
        UserId_TargetLanguage.AddOrUpdate(userId, languageId, (key, oldValue) => languageId);
    }

    public void AddOrUpdateUserEnglishMeaning(long userId, bool flag)
    {
        UserId_RecognizeMeaning.AddOrUpdate(userId, flag, (key, oldValue) => flag);
    }

    // DELETE
    public void DeleteUserNativeLanguage(long userId)
    {
        UserId_NativeLanguage.Remove(userId, out var language);
    }

    public void DeleteUserTargetLanguage(long userId)
    {
        UserId_TargetLanguage.Remove(userId, out var language);
    }

    public void DeleteUserRecognizeMeaning(long userId)
    {
        UserId_RecognizeMeaning.Remove(userId, out var flag);
    }

    // GET

    public bool IsEnglishMeaningActive(long userId)
    {
        var isExist = UserId_RecognizeMeaning.TryGetValue(userId, out var value);
        return isExist && value;
    }

    public LanguageENUM GetUserNativeLanguage(long userId)
    {
        return UserId_NativeLanguage.GetValueOrDefault(userId);
    }

    public LanguageENUM GetUserTargetLanguage(long userId)
    {
        return UserId_TargetLanguage.GetValueOrDefault(userId);
    }


    public List<Language> GetUserLanguages(long userId)
    {
        var languages = new List<Language>();

        if (UserId_NativeLanguage.ContainsKey(userId))
        {
            var languageId = UserId_NativeLanguage[userId];
            languages.Add(SupportedLanguages.languagesDict[languageId]);
        }

        if (UserId_TargetLanguage.ContainsKey(userId))
        {
            var languageId = UserId_TargetLanguage[userId];
            languages.Add(SupportedLanguages.languagesDict[languageId]);
        }

        return languages;
    }

    public bool IsNativeLanguageSetted(long userId) => UserId_NativeLanguage.ContainsKey(userId);

    public bool IsTargetLanguageSetted(long userId) => UserId_TargetLanguage.ContainsKey(userId);

    public bool IsLanguagesInited(long userId)
    {
        return IsNativeLanguageSetted(userId) && IsTargetLanguageSetted(userId);
    }

}
