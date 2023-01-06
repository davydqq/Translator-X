using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Meaning.Entities;

namespace TB.Meaning.Commands;

public class GetPhraseMeaningCommandHandler : ICommandHandler<GetPhraseMeaningCommand, MeaningResult>
{
    private readonly ILogger<GetPhraseMeaningCommandHandler> logger;

    private readonly IRepository<TextRequest, int> textRequestRepository;

    private readonly CambridgeDictionaryService cambridgeDictionaryService;

    public GetPhraseMeaningCommandHandler(
        ILogger<GetPhraseMeaningCommandHandler> logger,
        IRepository<TextRequest, int> textRequestRepository,
        CambridgeDictionaryService cambridgeDictionaryService)
    {
        this.logger = logger;
        this.textRequestRepository = textRequestRepository;
        this.cambridgeDictionaryService = cambridgeDictionaryService;
    }

    public async Task<MeaningResult> HandleAsync(GetPhraseMeaningCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text null");
            return null;
        }

        var texts = new string[] { command.Text };
        var request = new TextRequest(ApiTypeENUM.Cambridge, texts, 0).InitMeaning();

        var res = await cambridgeDictionaryService.GetCambridgeEnglishAsync(command.Text);

        request.InitResponse(JsonConvert.SerializeObject(res));
        await textRequestRepository.AddAsync(request);

        return res;
    }
}
