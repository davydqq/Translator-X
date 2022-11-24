namespace TB.ComputerVision.Entities;

public class VisionResult
{
    public List<Tag> Tags { set; get; }

    public Description Description { set; get; }

    public bool isSuccess { set; get; }
}

public class Tag
{
    public string Name { get; set; }

    public double Confidence { get; set; }

    public string Hint { get; set; }

    public Tag(string name, double confidence, string hint)
    {
        Name = name;
        Confidence = confidence;
        Hint = hint;
    }
}

public class Description
{
    public IList<string> Tags { get; set; }

    public IList<ImageCaption> Captions { get; set; }
}

public class ImageCaption
{
    public string Text { get; set; }

    public double Confidence { get; set; }

    public ImageCaption(string text, double confidence)
    {
        Text = text;
        Confidence = confidence;
    }
}
     
