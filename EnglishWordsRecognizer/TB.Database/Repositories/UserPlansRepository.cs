using Microsoft.EntityFrameworkCore;
using TB.Common;
using TB.Database.Entities.Users;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class UserPlansRepository : Repository<UserPlan, int>
{
	public UserPlansRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

	}

	public Task<UserPlan> GetUserPlan(long userId)
	{
		// TODO CHECK ORDER
		return entities
				.Include(x => x.Plan)
				.OrderBy(x => x.Plan.Priority)
				.FirstOrDefaultAsync(x => x.UserId == userId && TimeProvider.Get() < x.ExpireDate);
	}
}
