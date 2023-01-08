using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class TelegramUserRepository : Repository<TelegramUser, int>
{
	public TelegramUserRepository(TBDatabaseContext databaseContext) : base(databaseContext)
	{

	}
}
