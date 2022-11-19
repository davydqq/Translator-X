using Telegram.Bot.Types;
using TelegramBotCommands.Commands;
using TelegramBotCommands.Commands.CallbackCommands;
using TelegramBotCommands.Commands.CoreCommands;
using TelegramBotCommands.Commands.MenuCommands;

namespace TelegramBotCommands.Services;

public class CommandsHandlerService
{
    private List<IBaseCommand> commands = new List<IBaseCommand>();

    public IReadOnlyList<IBaseCommand> Commands => commands.OrderBy(x => x.Order).ToList().AsReadOnly();

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
                await command.ExecuteAsync(update, service);
                return true;
            }
        }

        return false;
    }

    public void InitCommands()
    {
        commands.Add(new StartTextCommand(new StartTextCommandOptions { IsDeleteCurrentMessage = true }));
        commands.Add(new GetInfoTextCommand(new GetInfoTextCommandOptions() {  IsDeleteCurrentMessage = true }));

        commands.Add(new ChangeTargetLanguageTextCommand(new ChangeTargetLanguageTextCommandOptions() { IsDeleteCurrentMessage = true }));
        commands.Add(new ChangeNativeLanguageTextCommand(new ChangeNativeLanguageTextCommandOptions() {  IsDeleteCurrentMessage = true }));

        commands.Add(new ChangeNativeLanguageCallbackCommand(new ChangeNativeLanguageCommandOptions() { IsDeleteCurrentMessage = true }));
        commands.Add(new ChangeTargetLanguageCallbackCommand(new ChangeTargetLanguageCallbackCommandOptions() { IsDeleteCurrentMessage = true }));

        // Recognize Commands
        commands.Add(new HandleImagesCommand());
        commands.Add(new HandleDocumentsCommand());
        commands.Add(new HandleAudiosCommand());
        commands.Add(new HandleVideosCommand());
        commands.Add(new HandleReplyCommand());
        commands.Add(new HandleTextCommand());

        commands.Add(new OtherCommand());
    }
}