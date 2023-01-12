using TB.Database.Entities;
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

    // IMAGES
    public async Task<(List<ImageRequest> request, UserPlan plan)> GetPaidPlanImageRequestsAsync(long userId)
    {
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId);
        if (userPlan == null)
        {
            throw new Exception("User plan cannot be null");
        }

        var imageCountRequests = await imageRequestRepository.GetWhereAsync(
                x => x.UserId == userId &&
                x.UserPlanId == userPlan.Id &&
                x.IsSuccess &&
                x.RequestCost != 0);

        return (imageCountRequests, userPlan);
    }

    public async Task<bool> IsCanProcessImageAsync(long userId)
	{
        var resp = await GetPaidPlanImageRequestsAsync(userId);

        if (resp.request.Count == 0) return true;

        var totalRequests = resp.request.Count;

        var plan = planCacheRepository.GetByKeyOrDefault(resp.plan.PlanId);

        if (totalRequests >= plan.MaxAnalysisPhotoCountMonth)
        {
            return false;
        }

        return true;
    }

    // TEXTS
    public async Task<(List<TextRequest> request, UserPlan plan)> GetPaidPlanTextRequestAsync(long userId)
    {
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId);
        if (userPlan == null)
        {
            throw new Exception("User plan cannot be null");
        }

        var types = new List<TextRequestTypeENUM> { TextRequestTypeENUM.Translate }; 

        var textCountRequests = await textRequestRepository.GetWhereAsync(
                x => x.UserId == userId &&
                x.UserPlanId == userPlan.Id &&
                x.IsSuccess &&
                types.Contains(x.TextRequestTypeId) &&
                x.RequestCost != 0);

        return (textCountRequests, userPlan);
    }

    public async Task<bool> IsCanProcessTextAsync(long userId)
    {
        var resp = await GetPaidPlanTextRequestAsync(userId);

        if (resp.request.Count == 0) return true;

        var totalChars = resp.request.Sum(x => x.TotalChars);

        var plan = planCacheRepository.GetByKeyOrDefault(resp.plan.PlanId);
        if (totalChars >= plan.MaxTranslateCharsMonth)
        {
            return false;
        }

        return true;
    }

    // AUDIOS
    public async Task<(List<AudioRequest> request, UserPlan plan)> GetPaidPlanAudioRequestAsync(long userId)
    {
        var user = await telegramUserRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);
        var userPlan = await paymentRepository.GetUserPlan(userId);
        if (userPlan == null)
        {
            throw new Exception("User plan cannot be null");
        }

        var plan = planCacheRepository.GetByKeyOrDefault(userPlan.PlanId);

        var audioRequests = await audioRequestRepository.GetWhereAsync(
                x => x.UserId == userId &&
                x.UserPlanId == userPlan.Id &&
                x.IsSuccess &&
                x.RequestCost != 0);

        return (audioRequests, userPlan);
    }

    public async Task<bool> IsCanProcessAudioAsync(long userId)
    {
        var resp = await GetPaidPlanAudioRequestAsync(userId);

        if (resp.request.Count == 0) return true;

        var sumSeconds = resp.request.Sum(x => x.ProcessedSeconds);

        var plan = planCacheRepository.GetByKeyOrDefault(resp.plan.PlanId);
        if (sumSeconds >= plan.MaxAudioTranscriptionSecondsMonth)
        {
            return false;
        }

        return true;
    }
}
