using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class PlanCacheRepository : CacheRepository<Plan, PlanENUM, PlanENUM>
{
	public PlanCacheRepository(TBDatabaseContext databaseContext) : base(databaseContext)
	{

	}

    public override void CreateDictionaryByKey()
    {
        if (cachedEnts.Count > 0)
        {
            cachedDictionary = cachedEnts.ToDictionary(x => x.Id);
        }
        else
        {
            cachedDictionary = new();
        }
    }

    public override Plan GetByKeyOrDefault(PlanENUM key)
    {
        InitAsync();

        if (cachedDictionary.ContainsKey(key))
        {
            return cachedDictionary[key];
        }

        return null!;
    }
}
