namespace TB.Menu;

public enum BotMenuId
{
    Start = 1,
    NativeLanguage = 2,
    TargetLanguage = 3,
    Info = 4,
}

public class BotMenuCommand
{
    public BotMenuId Id { get; set; }

    public string Name { set; get; }

    public string Description { set; get; }

    public string? CallBackId { set; get; }
}

public class BotMenuConfig
{
    public List<BotMenuCommand> Commands { set; get; }
}
