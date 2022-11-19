using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramBotImages.Entities;

namespace TelegramBotImages;

public class ImageProcessService
{
    private readonly IOptions<AzureVisionConfig> options;

    private readonly ComputerVisionClient client;

    public ImageProcessService(IOptions<AzureVisionConfig> options)
	{
        this.options = options;
        client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(this.options.Value.Key)) { Endpoint = this.options.Value.Endpoint };
    }

    public async Task AnalyzeImageUrl(string imageUrl)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("ANALYZE IMAGE - URL");
        Console.WriteLine();

        // Creating a list that defines the features to be extracted from the image. 

        List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags
            };

        Console.WriteLine($"Analyzing the image {Path.GetFileName(imageUrl)}...");
        Console.WriteLine();
        // Analyze the URL image 
        ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);

        // Image tags and their confidence score
        Console.WriteLine("Tags:");
        foreach (var tag in results.Tags)
        {
            Console.WriteLine($"{tag.Name} {tag.Confidence}");
        }
        Console.WriteLine();
    }
}
