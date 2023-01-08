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

	private readonly IRepository<Payment, int> paymentRepository;

	public BillingPlanService(
		IRepository<ImageRequest, int> imageRequestRepository,
        IRepository<TextRequest, int> textRequestRepository,
        IRepository<AudioRequest, int> audioRequestRepository,
        TelegramUserRepository telegramUserRepository,
        PlanCacheRepository planCacheRepository,
		IRepository<Payment, int> paymentRepository)
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
		var plan = user != null ? (await planCacheRepository.FirstOrDefaultAsync(x => x.Id == user.PlanId)) : null;

        if (plan != null)
		{
			var countRequests = await imageRequestRepository.GetCountAsync(x => x.UserId == userId);

			// TODO
        }

		return false;
    }
}
