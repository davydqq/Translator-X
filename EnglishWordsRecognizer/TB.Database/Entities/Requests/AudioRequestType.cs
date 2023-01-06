using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("AudioRequestTypes", Schema = "requests")]
public class AudioRequestType: BaseEntity<AudioRequestTypeENUM>
{
    public string Name { set; get; }
}
