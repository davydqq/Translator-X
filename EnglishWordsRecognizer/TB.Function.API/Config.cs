using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TB.Function.API.Services;

namespace TB.Function.API
{
    public class Config
    {
        private readonly ILogger _logger;

        private readonly RunAppService runAppService;

        public Config(ILoggerFactory loggerFactory, RunAppService runAppService)
        {
            _logger = loggerFactory.CreateLogger<Config>();
            this.runAppService = runAppService;
        }

        [Function(nameof(Config))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Admin, "get", "post")] HttpRequestData req)
        {
            await runAppService.RunAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Setted");

            return response;
        }
    }
}
