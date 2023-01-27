using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;

namespace TB.ComputerVision;

public class AzureComputerVisionService : IComputerVisionService
{
    private readonly IOptions<AzureVisionConfig> options;
    private readonly ILogger<AzureComputerVisionService> logger;
    private readonly ComputerVisionClient client;

    public AzureComputerVisionService(IOptions<AzureVisionConfig> options, ILogger<AzureComputerVisionService> logger)
    {
        this.options = options;
        this.logger = logger;
        client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(this.options.Value.Key)) { Endpoint = this.options.Value.Endpoint };
    }

    public ApiTypeENUM apiTypeENUM => ApiTypeENUM.Azure;

    public double Costs => APICosts.AzureImageI;

    public async Task<VisionResult> AnalyzeImageAsync(byte[] bytes)
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

            if(results == null) return new VisionResult();

            return new VisionResult
            {
                Tags = results.Tags.Select(x => new Tag(x.Name, x.Confidence, x.Hint)).ToList(),
                isSuccess = true,
                Description = new Description
                {
                    Captions = results.Description.Captions.Select(x => new Entities.ImageCaption(x.Text, x.Confidence)).ToList(),
                    Tags = results.Description.Tags
                }
            };
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
        }

        return new VisionResult();
    }

    public async Task<OCR_Result> OCRImageAsync(byte[] bytes)
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

            if (results.Status == OperationStatusCodes.Failed)
            {
                return new OCR_Result();
            }

            return new OCR_Result 
            {
                IsSuccess = true,
                TextResults = results.AnalyzeResult.ReadResults.Select(x => new TextResult
                {
                    Angle = x.Angle,
                    Height = x.Height,
                    Page = x.Page,
                    Width = x.Width,
                    Language = x.Language,
                    Lines = x.Lines.Select(q => new Result_Line
                    {
                        BoundingBox = q.BoundingBox,
                        Language = q.Language,
                        Text = q.Text,
                        Words = q.Words.Select(v => new Result_Word
                        {
                            BoundingBox = v.BoundingBox,
                            Confidence = v.Confidence,
                            Text = v.Text
                        }).ToList()
                    }).ToList()
                }).ToList()
            };
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
        }

        return new OCR_Result();
    }

}
