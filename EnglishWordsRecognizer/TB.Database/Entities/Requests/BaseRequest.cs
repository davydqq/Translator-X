using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table(nameof(BaseRequest), Schema = "requests")]
public class BaseRequest : BaseEntity<int>
{
    public DateTimeOffset RequestTime { set; get; }

	public BaseRequest(DateTimeOffset requestTime)
	{
		RequestTime = requestTime;
	}
}
