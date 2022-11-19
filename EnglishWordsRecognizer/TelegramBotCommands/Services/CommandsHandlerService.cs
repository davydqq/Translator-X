﻿using System.Runtime.InteropServices;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotCommands.Commands;
using TelegramBotCommands.Commands.CallbackCommands;
using TelegramBotCommands.Commands.MenuCommands;
using TelegramBotCommands.Entities;
using TelegramBotManager;

namespace TelegramBotCommands.Services;

public class CommandsHandlerService
{
    private List<IBaseCommand> commands = new List<IBaseCommand>();

    public IReadOnlyList<IBaseCommand> Commands => commands.AsReadOnly();

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
        commands.Add(new StartTextCommand());
        commands.Add(new GetInfoTextCommand());

        commands.Add(new ChangeTargetLanguageTextCommand(new ChangeTargetLanguageTextCommandOptions()));
        commands.Add(new ChangeNativeLanguageTextCommand(new ChangeNativeLanguageTextCommandOptions()));

        commands.Add(new ChangeNativeLanguageCallbackCommand(new ChangeNativeLanguageCommandOptions()));
        commands.Add(new ChangeTargetLanguageCallbackCommand(new ChangeTargetLanguageCallbackCommandOptions()));

        commands.Add(new OtherCommand());
    }
}