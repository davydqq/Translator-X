using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotCommands.Services;

namespace EnglishWordsRecognizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly FacadTelegramBotService facadTelegramBotService;

        private readonly CommandsHandlerService commandsHandler;

        public AppController(FacadTelegramBotService facadTelegramBotService, CommandsHandlerService commandsHandler)
        {
            this.facadTelegramBotService = facadTelegramBotService;
            this.commandsHandler = commandsHandler;
        }

        [HttpPost("updates")]
        public async Task<ActionResult> Post([FromBody] Update update)
        {
            if (update == null) return BadRequest("Update is empty");

            var res = await commandsHandler.HandleCommand(update, facadTelegramBotService);

            if (res)
            {
                return Ok();
            }

            return Ok("Command not found");
        }
    }
}
