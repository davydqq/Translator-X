namespace TB.Database.Entities;

public class UserSettings : BaseEntity<int>
{
    public LanguageENUM? NativeLanguageId { set; get; }
    public Language NativeLanguage { set; get; }

    public LanguageENUM? TargetLanguageId { set; get; }
    public Language TargetLanguage { set; get; }

    public LanguageENUM? InterfaceLanguageId { set; get; }
    public Language InterfaceLanguage { set; get; }

    public bool RecognizeEnglishMeaning { set; get; }


    public long TelegramUserId { set; get; }
    public TelegramUser TelegramUser { set; get; }
}
