using System.Runtime.InteropServices;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Commands;
using TelegramBotManager;

namespace TelegramBotCommands.Services;

public class CommandsHandlerService
{
    private List<BaseCommand> commands = new List<BaseCommand>();

    public IReadOnlyList<BaseCommand> Commands => commands.AsReadOnly();

    public CommandsHandlerService()
    {
        InitCommands();
    }

    public async Task<bool> HandleCommand(Update update, FacadTelegramBotService service)
    {
        foreach (var command in Commands)
        {
            if (command.CanHandle(update))
            {
                await command.Execute(update, service);
                return true;
            }
        }

        return false;
    }

    public void InitCommands()
    {
        commands.Add(new StartTextCommand());
        commands.Add(new LanguageTextCommand());
        commands.Add(new ChangeLanguageCommand());
        commands.Add(new OtherCommand());
    }
}