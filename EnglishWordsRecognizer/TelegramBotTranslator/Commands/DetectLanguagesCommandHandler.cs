using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.Repositories;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class DetectLanguagesCommandHandler : ICommandHandler<DetectLanguagesCommand, List<DetectLanguageResponse>>
{
    private readonly ILogger<DetectLanguagesCommandHandler> logger;

    private readonly ITranslateService translateService;

    private readonly TextRequestRepository textRequestRepository;

    private readonly UserPlansRepository userPlansRepository;

    public DetectLanguagesCommandHandler(
        ILogger<DetectLanguagesCommandHandler> logger,
        ITranslateService translateService,
        TextRequestRepository textRequestRepository,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.translateService = translateService;
        this.textRequestRepository = textRequestRepository;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<List<DetectLanguageResponse>> HandleAsync(DetectLanguagesCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.TextToDetect))
        {
            logger.LogError("TextToDetect null");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);

        var texts = new string[] { command.TextToDetect };
        var request = new TextRequest(translateService.apiTypeENUM, texts, translateService.Costs, command.UserId, plan.Id)
                            .InitDetectLanguages();

        var resp = await translateService.DetectLanguagesAsync(texts);

        var isSuccess = resp == null ? false : true;
        var resJson = isSuccess ? JsonConvert.SerializeObject(resp) : null;
        request.InitResponse(resJson, isSuccess);
        await textRequestRepository.AddAsync(request);

        return resp;
    }
}
