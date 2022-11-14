namespace TelegramBotStorage.Languages;

public class Language
{
    public LanguageENUM Id { set; get; }

    public string Name { set; get; }

    public Language(LanguageENUM id, string name)
    {
        Id = id;
        Name = name;
    }
}
