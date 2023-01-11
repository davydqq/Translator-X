﻿using Microsoft.EntityFrameworkCore;
using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class UserPlansRepository : Repository<UserPlan, int>
{
	public UserPlansRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

	}

	public Task<UserPlan> GetUserPlan(long userId, DateTimeOffset currentDate)
	{
		// TODO CHECK ORDER
		return entities
				.OrderByDescending(x => x.PlanId)
				.FirstOrDefaultAsync(x => x.UserId == userId && currentDate < x.ExpireDate);
	}
}
