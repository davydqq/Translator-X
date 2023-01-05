using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("BasePayableRequests", Schema = "payable_requests")]
public class BasePayableRequest : BaseEntity<int>
{
    public DateTimeOffset RequestTime { set; get; }

	public BasePayableRequest(DateTimeOffset requestTime)
	{
		RequestTime = requestTime;
	}
}
