

using TB.ComputerVision.Entities;

namespace TB.ComputerVision;

public interface IComputerVisionService
{
    public Task<VisionResult> AnalyzeImageAsync(byte[] bytes);

    public Task<OCR_Result> OCRImageAsync(byte[] bytes);
}
