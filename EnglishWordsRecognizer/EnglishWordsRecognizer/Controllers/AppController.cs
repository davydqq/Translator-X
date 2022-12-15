using CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using TB.Routing.Commands;
using TB.User.Commands;
using Telegram.Bot.Types;

namespace TB.API.Controllers
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

            await dispatcher.DispatchAsync(new RegisterUserCommand(update));

            var res = await dispatcher.DispatchAsync(new TelegramUpdatesCommand(update));

            return Ok();
        }
    }
}
