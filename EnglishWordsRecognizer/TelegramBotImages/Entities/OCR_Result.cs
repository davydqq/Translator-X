namespace TB.ComputerVision.Entities;

public class OCR_Result
{
    public List<TextResult> TextResults { set; get; }

    public bool IsSuccess { set; get; }
}

public class TextResult
{
    public int Page { get; set; }

    public string Language { get; set; }

    public double Angle { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    // public TextRecognitionResultDimensionUnit Unit { get; set; }

    public IList<Result_Line> Lines { get; set; }
}

public class Result_Line
{
    public string Language { get; set; }

    public IList<double?> BoundingBox { get; set; }

    // public Appearance Appearance { get; set; }

    public string Text { get; set; }

    public IList<Result_Word> Words { get; set; }
}

public class Result_Word
{
    public IList<double?> BoundingBox { get; set; }

    public string Text { get; set; }

    public double Confidence { get; set; }
}
