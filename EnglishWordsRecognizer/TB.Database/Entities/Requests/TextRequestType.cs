using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("TextRequestTypes", Schema = "requests")]
public class TextRequestType : BaseEntity<TextRequestTypeENUM>
{
    public string Name { set; get; }

    public List<TextRequestType> TextRequestTypes { set; get; }
}
