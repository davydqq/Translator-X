using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class TranslateTextsCommandHandler : ICommandHandler<TranslateTextsCommand, List<TranslateResponse>>
{
    private readonly ILogger<TranslateTextsCommandHandler> logger;

    private readonly ITranslateService translateService;

    private readonly TextRequestRepository textRequestRepository;

    private readonly UserPlansRepository userPlansRepository;

    public TranslateTextsCommandHandler(
        ILogger<TranslateTextsCommandHandler> logger, 
        ITranslateService translateService,
        TextRequestRepository textRequestRepository,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.translateService = translateService;
        this.textRequestRepository = textRequestRepository;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<List<TranslateResponse>> HandleAsync(TranslateTextsCommand command, CancellationToken cancellation = default)
    {
        if (command.TextsToTranslate == null || command.TextsToTranslate.Count == 0)
        {
            logger.LogError("Texts To Translate empty");
            return null;
        }

        if (command.LanguagesToTranslate == null || command.LanguagesToTranslate.Count == 0)
        {
            logger.LogError("Languages To Translate empty");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);

        var texts = command.TextsToTranslate.ToArray();
        var languages = command.LanguagesToTranslate.ToArray();

        var request = new TextRequest(translateService.apiTypeENUM, texts, Costs.AzureCharTranslatePrice, command.UserId, plan.Id)
                            .InitTranslateTexts(languages);

        var resp = await translateService.TranslateTextsAsync(texts, languages);

        var isSuccess = resp == null ? false : true;
        var resJson = isSuccess ? JsonConvert.SerializeObject(resp) : null;
        request.InitResponse(resJson, isSuccess);
        await textRequestRepository.AddAsync(request);

        return resp;
    }
}
