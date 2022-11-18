using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotCommands.Commands;

public class BaseCommandOptions
{
    public List<FuncWrapper> CallBacksOnExecute { set; get; }
}


public class FuncWrapper
{
    public Func<bool> Func;

    public bool canRun;
}