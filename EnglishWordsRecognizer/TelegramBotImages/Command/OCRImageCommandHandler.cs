using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;
using TB.Database.Repositories;

namespace TB.ComputerVision.Command;

public class OCRImageCommandHandler : ICommandHandler<OCRImageCommand, OCR_Result>
{
	private readonly ILogger<OCRImageCommandHandler> logger;

	private readonly IComputerVisionService computerVisionService;

	private readonly ImageRequestRepository imageRequestRepository;

	private readonly UserPlansRepository userPlansRepository;

	public OCRImageCommandHandler(
		ILogger<OCRImageCommandHandler> logger, 
		IComputerVisionService computerVisionService,
        ImageRequestRepository imageRequestRepository,
        UserPlansRepository userPlansRepository)
	{
		this.logger = logger;
		this.computerVisionService = computerVisionService;
		this.imageRequestRepository = imageRequestRepository;
		this.userPlansRepository = userPlansRepository;
	}

	public async Task<OCR_Result> HandleAsync(OCRImageCommand command, CancellationToken cancellation = default)
	{
		if (command.Bytes ==  null || command.Bytes.Length == 0)
		{
            logger.LogError("Bytes null");
			return null;
		}

        var plan = await userPlansRepository.GetUserPlan(command.UserId);
        var request = new ImageRequest(computerVisionService.apiTypeENUM, computerVisionService.Costs, command.UserId, plan.Id).InitOCR();

        var results = await computerVisionService.OCRImageAsync(command.Bytes);

        request.InitResponse(JsonConvert.SerializeObject(results), results.IsSuccess);
		await imageRequestRepository.AddAsync(request);

        return results;
    }
}
