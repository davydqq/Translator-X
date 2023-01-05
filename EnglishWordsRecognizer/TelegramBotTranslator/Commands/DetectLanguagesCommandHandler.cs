using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class DetectLanguagesCommandHandler : ICommandHandler<DetectLanguagesCommand, List<DetectLanguageResponse>>
{
    private readonly ILogger<DetectLanguagesCommandHandler> logger;

    private readonly ITranslateService translateService;

    private readonly IRepository<TextRequest, int> textRequestRepository;

    public DetectLanguagesCommandHandler(
        ILogger<DetectLanguagesCommandHandler> logger,
        ITranslateService translateService,
        IRepository<TextRequest, int> textRequestRepository)
    {
        this.logger = logger;
        this.translateService = translateService;
        this.textRequestRepository = textRequestRepository;
    }

    public async Task<List<DetectLanguageResponse>> HandleAsync(DetectLanguagesCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.TextToDetect))
        {
            logger.LogError("TextToDetect null");
            return null;
        }

        var texts = new string[] { command.TextToDetect};
        var request = new TextRequest().InitDetectLanguages(texts, translateService.apiTypeENUM);

        var resp = await translateService.DetectLanguagesAsync(texts);

        request.InitResponse(JsonConvert.SerializeObject(resp));
        await textRequestRepository.AddAsync(request);

        return resp;
    }
}
