using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;

namespace TB.ComputerVision.Command;

public class AnalyseImageCommandHandler : ICommandHandler<AnalyzeImageCommand, VisionResult>
{
    private readonly ILogger<AnalyseImageCommandHandler> logger;

    private readonly IComputerVisionService computerVisionService;

    private readonly ImageRequestRepository imageRequestRepository;

    private readonly UserPlansRepository userPlansRepository;

    public AnalyseImageCommandHandler(
        ILogger<AnalyseImageCommandHandler> logger,
        IComputerVisionService computerVisionService,
        ImageRequestRepository imageRequestRepository,
        UserPlansRepository userPlansRepository)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.imageRequestRepository = imageRequestRepository;
        this.userPlansRepository = userPlansRepository;
    }

    public async Task<VisionResult> HandleAsync(AnalyzeImageCommand command, CancellationToken cancellation = default)
    {
        if (command.Bytes == null || command.Bytes.Length == 0)
        {
            logger.LogError("Bytes null");
            return null;
        }

        var plan = await userPlansRepository.GetUserPlan(command.UserId);
        var request = new ImageRequest(computerVisionService.apiTypeENUM, computerVisionService.Costs, command.UserId, plan.Id).InitImageAnalysis();

        var results = await computerVisionService.AnalyzeImageAsync(command.Bytes);

        request.InitResponse(JsonConvert.SerializeObject(results), results.isSuccess);
        await imageRequestRepository.AddAsync(request);

        return results;
    }
}
