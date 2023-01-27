

using TB.ComputerVision.Entities;
using TB.Database.Entities.Requests;

namespace TB.ComputerVision;

public interface IComputerVisionService
{
    public Task<VisionResult> AnalyzeImageAsync(byte[] bytes);

    public Task<OCR_Result> OCRImageAsync(byte[] bytes);

    ApiTypeENUM apiTypeENUM { get; }

    double Costs { get; }
}
