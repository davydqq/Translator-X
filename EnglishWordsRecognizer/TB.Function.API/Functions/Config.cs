using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TB.ComputerVision.Entities;
using TB.Core.Configs;
using TB.Menu.Entities;
using TB.Translator.Entities.Azure;

namespace TB.Function.API.Functions
{
    public class Config
    {
        private readonly ILogger _logger;

        private readonly IConfiguration configuration;

        private readonly IOptions<AzureVisionConfig> azureVisionConfig;
        private readonly IOptions<AzureTranslatorConfig> azureTranslatorConfig;
        private readonly IOptions<BotCredentialsConfig> botCredentialsConfig;

        public Config(
            ILoggerFactory loggerFactory, 
            IConfiguration configuration,
            IOptions<AzureVisionConfig> azureVisionConfig,
            IOptions<AzureTranslatorConfig> azureTranslatorConfig,
            IOptions<BotCredentialsConfig> botCredentialsConfig)
        {
            _logger = loggerFactory.CreateLogger<Config>();
            this.configuration = configuration;
            this.azureVisionConfig = azureVisionConfig;
            this.azureTranslatorConfig = azureTranslatorConfig;
            this.botCredentialsConfig = botCredentialsConfig;
        }

        [Function("Config")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Admin, "get", "post")] HttpRequestData req)
        {
            var dataBaseConn = configuration.GetValue<string>("Database");

            var resp = new string[] 
            {
                dataBaseConn,
                JsonConvert.SerializeObject(azureVisionConfig.Value),
                JsonConvert.SerializeObject(azureTranslatorConfig.Value),
                JsonConvert.SerializeObject(botCredentialsConfig.Value),
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");

            response.WriteString(JsonConvert.SerializeObject(resp));

            return response;
        }
    }
}
