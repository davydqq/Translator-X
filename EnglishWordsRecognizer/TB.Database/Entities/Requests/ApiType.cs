namespace TB.Database.Entities.Requests;

public class ApiType : BaseEntity<ApiTypeENUM>
{
    public string Name { set; get; }

    public List<BaseRequest> BaseRequests { set; get; }
}
