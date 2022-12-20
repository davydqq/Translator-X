namespace TB.Database.Entities;

public class Translation : BaseEntity<int>
{
    public string Key { set; get; }

    public LanguageENUM LanguageId { set; get; }
    public Language Language { set; get; }

    public string Translate { set; get; }
}
