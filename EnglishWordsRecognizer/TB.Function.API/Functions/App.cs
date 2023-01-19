using System.Net;
using CQRS.Commands;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Routing.Commands;
using TB.User.Commands;
using Telegram.Bot.Types;

namespace TB.Function.API.Functions
{
    public class App
    {
        private readonly ILogger _logger;

        private readonly ICommandDispatcher dispatcher;

        public App(ILoggerFactory loggerFactory, ICommandDispatcher dispatcher)
        {
            _logger = loggerFactory.CreateLogger<App>();
            this.dispatcher = dispatcher;
        }

        [Function(nameof(App))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var request = await req.ReadAsStringAsync();

            _logger.LogInformation("Request: ", request);

            var update = JsonConvert.DeserializeObject<Update>(request);

            if (update == null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                badResponse.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                badResponse.WriteString("Bad Request");
                return badResponse;
            }

            await dispatcher.DispatchAsync(new RegisterUserCommand(update));

            var res = await dispatcher.DispatchAsync(new TelegramUpdatesCommand(update));

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            return response;
        }
    }
}
