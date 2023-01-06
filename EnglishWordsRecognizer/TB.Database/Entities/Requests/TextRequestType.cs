namespace TB.Database.Entities.Requests;

public class TextRequestType : BaseEntity<TextRequestTypeENUM>
{
    public string Name { set; get; }

    public List<TextRequestType> TextRequestTypes { set; get; }
}
