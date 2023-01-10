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

	private readonly PaymentsRepository paymentRepository;

	public BillingPlanService(
		IRepository<ImageRequest, int> imageRequestRepository,
        IRepository<TextRequest, int> textRequestRepository,
        IRepository<AudioRequest, int> audioRequestRepository,
        TelegramUserRepository telegramUserRepository,
        PlanCacheRepository planCacheRepository,
        PaymentsRepository paymentRepository)
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

        if (user != null)
		{
			var imageCountRequests = await imageRequestRepository.GetCountAsync(x => x.UserId == userId); // todo per month
			var userPlan = await GetUserPlanAsync(userId);
            var plan = planCacheRepository.GetByKeyOrDefault(userPlan);

			if(imageCountRequests >= plan.MaxAnalysisPhotoCountMonth)
			{

			}
			// TODO
        }

		return false;
    }

	private async Task<PlanENUM> GetUserPlanAsync(long userId)
	{
        var payment = await paymentRepository.GetPayment(userId, DateTimeOffset.UtcNow);

		if(payment != null)
		{
            return payment.PlanId;
        }

		return PlanENUM.Standart;
    }
}
