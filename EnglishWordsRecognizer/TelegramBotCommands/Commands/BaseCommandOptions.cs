using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotCommands.Commands;

public class BaseCommandOptions
{
    public List<Action> CallBacksOnExecute { set; get; }
}
