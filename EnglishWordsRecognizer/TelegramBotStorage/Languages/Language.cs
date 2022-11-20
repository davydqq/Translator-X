namespace TelegramBotStorage.Languages;

public class Language
{
    public LanguageENUM Id { set; get; }

    public string Name { set; get; }

    public string Code { set; get; }

    public Language(LanguageENUM id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
}
