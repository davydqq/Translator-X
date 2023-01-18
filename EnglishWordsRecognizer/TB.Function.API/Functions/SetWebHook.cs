using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TB.Function.API.Services;

namespace TB.Function.API.Functions
{
    public class SetWebHook
    {
        private readonly ILogger _logger;

        private readonly RunAppService runAppService;

        public SetWebHook(ILoggerFactory loggerFactory, RunAppService runAppService)
        {
            _logger = loggerFactory.CreateLogger<SetWebHook>();
            this.runAppService = runAppService;
        }

        [Function(nameof(SetWebHook))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Admin, "get")] HttpRequestData req)
        {
            await runAppService.RunAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            _logger.LogInformation("Webhook setted");
            response.WriteString("Setted");

            return response;
        }
    }
}
