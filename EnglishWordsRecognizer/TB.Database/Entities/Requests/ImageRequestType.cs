using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("ImageRequestTypes", Schema = "requests")]
public class ImageRequestType : BaseEntity<ImageRequestTypeENUM>
{
    public string Name { set; get; }

    public List<ImageRequest> ImageRequests { set; get; }
}
