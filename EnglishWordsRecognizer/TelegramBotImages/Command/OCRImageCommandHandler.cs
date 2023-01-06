using CQRS.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;

namespace TB.ComputerVision.Command;

public class OCRImageCommandHandler : ICommandHandler<OCRImageCommand, OCR_Result>
{
	private readonly ILogger<OCRImageCommandHandler> logger;

	private readonly IComputerVisionService computerVisionService;

	private readonly IRepository<ImageRequest, int> imageRequestRepository;

	public OCRImageCommandHandler(
		ILogger<OCRImageCommandHandler> logger, 
		IComputerVisionService computerVisionService,
        IRepository<ImageRequest, int> imageRequestRepository)
	{
		this.logger = logger;
		this.computerVisionService = computerVisionService;
		this.imageRequestRepository = imageRequestRepository;
	}

	public async Task<OCR_Result> HandleAsync(OCRImageCommand command, CancellationToken cancellation = default)
	{
		if (command.Bytes ==  null || command.Bytes.Length == 0)
		{
            logger.LogError("Bytes null");
            return null;
        }

		var request = new ImageRequest(ApiTypeENUM.Azure, Costs.AzureImage).InitOCR();

        var results = await computerVisionService.OCRImageAsync(command.Bytes);

        request.InitResponse(JsonConvert.SerializeObject(results));
		await imageRequestRepository.AddAsync(request);

        return results;
    }
}
