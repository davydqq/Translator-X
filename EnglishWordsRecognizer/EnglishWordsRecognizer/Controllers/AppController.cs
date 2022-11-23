using CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotCommands;

namespace EnglishWordsRecognizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ICommandDispatcher dispatcher;

        public AppController(ICommandDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpPost("updates")]
        public async Task<ActionResult> Post([FromBody] Update update)
        {
            if (update == null) return BadRequest("Update is empty");

            await dispatcher.DispatchAsync(new TelegramUpdatesCommand(update));

            return Ok();
        }
    }
}
