using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Translator.Entities;

namespace TB.Translator.Commands;

public class TranslateTextsCommandHandler : ICommandHandler<TranslateTextsCommand, List<TranslateResponse>>
{
    private readonly ILogger<TranslateTextsCommandHandler> logger;

    private readonly ITranslateService translateService;

    private readonly IRepository<TextRequest, int> textRequestRepository;

    public TranslateTextsCommandHandler(
        ILogger<TranslateTextsCommandHandler> logger, 
        ITranslateService translateService,
        IRepository<TextRequest, int> textRequestRepository)
    {
        this.logger = logger;
        this.translateService = translateService;
        this.textRequestRepository = textRequestRepository;
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

        var texts = command.TextsToTranslate.ToArray();
        var languages = command.LanguagesToTranslate.ToArray();
        var request = new TextRequest().InitTranslateTexts(texts, languages, translateService.apiTypeENUM);

        var resp = await translateService.TranslateTextsAsync(texts, languages);

        request.InitResponse(JsonConvert.SerializeObject(resp));
        await textRequestRepository.AddAsync(request);

        return resp;
    }
}
