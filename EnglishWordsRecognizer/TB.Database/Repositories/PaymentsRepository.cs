using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class PaymentsRepository : Repository<Payment, int>
{
	public PaymentsRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

	}

	public Task<Payment> GetPayment(long userId, DateTimeOffset currentDate)
	{
		return entities.FirstOrDefaultAsync(x => x.UserId == userId && currentDate < x.ExpireDate);
	}
}
