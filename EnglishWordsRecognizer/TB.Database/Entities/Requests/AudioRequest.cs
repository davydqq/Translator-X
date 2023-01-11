using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;


[Table("AudioRequests", Schema = "requests")]
public class AudioRequest: BaseRequest
{

    public AudioRequestTypeENUM AudioRequestTypeId { set; get; }
	public AudioRequestType AudioRequestType { set; get; }

    public long ProcessedSeconds { set; get; }

    public double SecondCost { set; get; }

    public AudioRequest() : base(DateTimeOffset.UtcNow, null, 0, 0)
    {

	}

    public AudioRequest(ApiTypeENUM? apiTypeId, long userId, int userPlanId) : base(DateTimeOffset.UtcNow, apiTypeId, userId, userPlanId)
    {
    }

    public AudioRequest InitTranscription(long durationSeconds, double costSecond)
    {
        AudioRequestTypeId = AudioRequestTypeENUM.Transcription;
        ProcessedSeconds = durationSeconds;
        SecondCost = costSecond;
        InitCost(durationSeconds * costSecond);

        return this;
    }
}
