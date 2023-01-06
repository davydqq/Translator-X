namespace TB.Database.Entities.Requests;

public class ImageRequestType : BaseEntity<ImageRequestTypeENUM>
{
    public string Name { set; get; }

    public List<ImageRequest> ImageRequests { set; get; }
}
