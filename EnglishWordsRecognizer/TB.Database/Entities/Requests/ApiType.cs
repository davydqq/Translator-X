using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("ApiTypes", Schema = "requests")]
public class ApiType : BaseEntity<ApiTypeENUM>
{
    public string Name { set; get; }

    public List<BaseRequest> BaseRequests { set; get; }
}
