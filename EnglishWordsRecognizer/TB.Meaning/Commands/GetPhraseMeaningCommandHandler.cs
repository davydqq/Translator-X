using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;
using TB.Meaning.Entities;

namespace TB.Meaning.Commands;

public class GetPhraseMeaningCommandHandler : ICommandHandler<GetPhraseMeaningCommand, MeaningResult>
{
    private readonly ILogger<GetPhraseMeaningCommandHandler> logger;

    private readonly TextRequestRepository textRequestRepository;

    private readonly CambridgeDictionaryService cambridgeDictionaryService;

    private readonly UserPlansRepository userPlansRepository;

    public GetPhraseMeaningCommandHandler(
        ILogger<GetPhraseMeaningCommandHandler> logger,
        TextRequestRepository textRequestRepository,
        CambridgeDictionaryService cambridgeDictionaryService,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.textRequestRepository = textRequestRepository;
        this.cambridgeDictionaryService = cambridgeDictionaryService;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<MeaningResult> HandleAsync(GetPhraseMeaningCommand command, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(command.Text))
        {
            logger.LogError("Text null");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);

        var texts = new string[] { command.Text };
        var request = new TextRequest(ApiTypeENUM.Cambridge, texts, 0, command.UserId, plan.Id).InitMeaning();

        var resp = await cambridgeDictionaryService.GetCambridgeEnglishAsync(command.Text);

        var isSuccess = resp == null ? false : true;
        var resJson = isSuccess ? JsonConvert.SerializeObject(resp) : null;
        request.InitResponse(resJson, isSuccess);
        await textRequestRepository.AddAsync(request);

        return resp;
    }
}
