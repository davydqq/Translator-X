using TB.Database.Entities.Requests;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;

namespace TB.BillingPlans;

public class BillingPlanService : IBillingPlanService
{
	private readonly IRepository<ImageRequest, int> imageRequestRepository;

	private readonly IRepository<TextRequest, int> textRequestRepository;

	private readonly IRepository<AudioRequest, int> audioRequestRepository;

	private readonly TelegramUserRepository telegramUserRepository;

	private readonly PlanCacheRepository planCacheRepository;

	private readonly UserPlansRepository paymentRepository;

	public BillingPlanService(
		IRepository<ImageRequest, int> imageRequestRepository,
        IRepository<TextRequest, int> textRequestRepository,
        IRepository<AudioRequest, int> audioRequestRepository,
        TelegramUserRepository telegramUserRepository,
        PlanCacheRepository planCacheRepository,
        UserPlansRepository paymentRepository)
	{
		this.imageRequestRepository = imageRequestRepository;
		this.textRequestRepository = textRequestRepository;
		this.audioRequestRepository = audioRequestRepository;
		this.telegramUserRepository = telegramUserRepository;
		this.planCacheRepository = planCacheRepository;
		this.paymentRepository = paymentRepository;
	}

	public async Task<bool> IsCanProcessImageAsync(long userId)
	{
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId, DateTimeOffset.UtcNow);
        if (userPlan == null)
        {
            throw new Exception("Payment cannot be null");
        }

        var plan = planCacheRepository.GetByKeyOrDefault(userPlan.PlanId);

		var imageCountRequests = await imageRequestRepository.GetCountAsync(
                x => x.UserId == userId && 
				x.RequestTime > userPlan.StartDate && x.RequestTime < userPlan.ExpireDate &&
                x.IsSuccess &&
                x.RequestCost != 0);

        if (imageCountRequests >= plan.MaxAnalysisPhotoCountMonth)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> IsCanProcessTextAsync(long userId)
    {
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId, DateTimeOffset.UtcNow);
        if (userPlan == null)
        {
            throw new Exception("Payment cannot be null");
        }

        var plan = planCacheRepository.GetByKeyOrDefault(userPlan.PlanId);

        var textCountRequests = await textRequestRepository.GetWhereAsync(
                x => x.UserId == userId &&
                x.RequestTime > userPlan.StartDate && x.RequestTime < userPlan.ExpireDate &&
                x.IsSuccess &&
                x.RequestCost != 0);

        if (textCountRequests.Count == 0) return false;

        var totalChars = textCountRequests.Sum(x => x.TotalChars);

        if (totalChars >= plan.MaxTranslateCharsMonth)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> IsCanProcessAudioAsync(long userId)
    {
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId, DateTimeOffset.UtcNow);
        if (userPlan == null)
        {
            throw new Exception("Payment cannot be null");
        }

        var plan = planCacheRepository.GetByKeyOrDefault(userPlan.PlanId);

        var audioRequests = await audioRequestRepository.GetWhereAsync(
                x => x.UserId == userId &&
                x.RequestTime > userPlan.StartDate && x.RequestTime < userPlan.ExpireDate &&
                x.IsSuccess &&
                x.RequestCost != 0);

        if (audioRequests.Count == 0) return false;

        var sumSeconds = audioRequests.Sum(x => x.ProcessedSeconds);

        if (sumSeconds >= plan.MaxAudioTranscriptionSecondsMonth)
        {
            return false;
        }

        return true;
    }
}
