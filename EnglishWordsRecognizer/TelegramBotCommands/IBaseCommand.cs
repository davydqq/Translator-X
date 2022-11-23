using Telegram.Bot.Types;
using TelegramBotCommands.Entities;
using TelegramBotCommands.Services;

namespace TelegramBotCommands;

public interface IBaseCommand 
{
    public Task<BaseCommandResult> ExecuteAsync(Update update);

    public bool CanHandle(Update update);

    public int Order { get; }
}
