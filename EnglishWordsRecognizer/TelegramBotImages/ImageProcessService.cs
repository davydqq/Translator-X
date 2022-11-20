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

    public async Task<ImageAnalysis> AnalyzeImage(MemoryStream imageSteam)
    {
        // Creating a list that defines the features to be extracted from the image. 

        List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
        {
            VisualFeatureTypes.Tags
        };

        var results = await AnalyzeImage(imageSteam, features);

        if (results == null) return null;

        Console.WriteLine("Tags:");
        foreach (var tag in results.Tags)
        {
            Console.WriteLine($"{tag.Name} {tag.Confidence}");
        }
        Console.WriteLine();

        return results;
    }

    private async Task<ImageAnalysis> AnalyzeImage(MemoryStream imageSteam, List<VisualFeatureTypes?> features)
    {
        try
        {
            ImageAnalysis results = await client.AnalyzeImageInStreamAsync(imageSteam, visualFeatures: features);
            return results;
        } catch(Exception e)
        {
            logger.LogError(e.Message);
        }

        return null;
    }
}
