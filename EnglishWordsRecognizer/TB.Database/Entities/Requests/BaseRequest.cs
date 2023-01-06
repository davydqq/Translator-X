using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table(nameof(BaseRequest), Schema = "requests")]
public class BaseRequest : BaseEntity<int>
{
    public DateTimeOffset RequestTime { set; get; }

	public double RequestCost { set; get; }

    public ApiTypeENUM ApiTypeId { set; get; }
    public ApiType ApiType { set; get; }

	public BaseRequest(DateTimeOffset requestTime, ApiTypeENUM apiTypeId)
	{
		RequestTime = requestTime;
		ApiTypeId = apiTypeId;
	}
}
