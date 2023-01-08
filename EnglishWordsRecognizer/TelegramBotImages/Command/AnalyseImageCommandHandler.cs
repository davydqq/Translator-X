using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;

namespace TB.ComputerVision.Command;

public class AnalyseImageCommandHandler : ICommandHandler<AnalyzeImageCommand, VisionResult>
{
    private readonly ILogger<AnalyseImageCommandHandler> logger;

    private readonly IComputerVisionService computerVisionService;

    private readonly IRepository<ImageRequest, int> imageRequestRepository;

    public AnalyseImageCommandHandler(
        ILogger<AnalyseImageCommandHandler> logger,
        IComputerVisionService computerVisionService,
        IRepository<ImageRequest, int> imageRequestRepository)
    {
        this.logger = logger;
        this.computerVisionService = computerVisionService;
        this.imageRequestRepository = imageRequestRepository;
    }

    public async Task<VisionResult> HandleAsync(AnalyzeImageCommand command, CancellationToken cancellation = default)
    {
        if (command.Bytes == null || command.Bytes.Length == 0)
        {
            logger.LogError("Bytes null");
            return null;
        }

        var request = new ImageRequest(ApiTypeENUM.Azure, Costs.AzureImage, command.UserId).InitImageAnalysis();

        var results = await computerVisionService.AnalyzeImageAsync(command.Bytes);

        request.InitResponse(JsonConvert.SerializeObject(results), results.isSuccess);
        await imageRequestRepository.AddAsync(request);

        return results;
    }
}
