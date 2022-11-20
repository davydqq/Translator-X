using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TelegramBotImages.Entities;

namespace TelegramBotImages;

public class ImageProcessService
{
    private readonly IOptions<AzureVisionConfig> options;
    private readonly ILogger<ImageProcessService> logger;
    private readonly ComputerVisionClient client;

    public ImageProcessService(IOptions<AzureVisionConfig> options, ILogger<ImageProcessService> logger)
	{
        this.options = options;
        this.logger = logger;
        client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(this.options.Value.Key)) { Endpoint = this.options.Value.Endpoint };
    }

    public async Task<ImageAnalysis> AnalyzeImage(byte[] bytes)
    {
        try
        {
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Description,
            };

            using Stream imageSteam = new MemoryStream(bytes);
            ImageAnalysis results = await client.AnalyzeImageInStreamAsync(imageSteam, visualFeatures: features);

            Console.WriteLine("Tags:");
            foreach (var tag in results.Tags)
            {
                Console.WriteLine($"{tag.Name} {tag.Confidence}");
            }

            return results;
        } catch(Exception e)
        {
            logger.LogError(e.Message);
        }

        return null;
    }

    public async Task<List<ReadResult>> OCRImage(byte[] bytes)
    {
        try
        {
            using Stream imageSteam = new MemoryStream(bytes);

            // Read text from URL
            var textHeaders = await client.ReadInStreamAsync(imageSteam);
            // After the request, get the operation location (operation ID)
            string operationLocation = textHeaders.OperationLocation;

            // Retrieve the URI where the extracted text will be stored from the Operation-Location header.
            // We only need the ID and not the full URL
            const int numberOfCharsInOperationId = 36;
            string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

            // Extract the text
            ReadOperationResult results;

            do
            {
                await Task.Delay(500);
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

            // Display the found text.
            var textUrlFileResults = results.AnalyzeResult.ReadResults;
            foreach (ReadResult page in textUrlFileResults)
            {
                foreach (Line line in page.Lines)
                {
                    Console.WriteLine(line.Text);
                }
            }

            return results.AnalyzeResult.ReadResults.ToList();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
        }

        return null;
    }

}
