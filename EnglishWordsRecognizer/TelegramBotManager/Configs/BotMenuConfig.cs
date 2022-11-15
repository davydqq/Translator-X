namespace TelegramBotManager.Configs;

public class BotMenuCommand
{
    public string Name { set; get; }

    public string Description { set; get; }
}

public class BotMenuConfig
{
    public List<BotMenuCommand> Commands { set; get; }
}
