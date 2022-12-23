using TB.Database.Entities;
using TB.Database.GenericRepositories;

namespace TB.Database.Repositories;

public class TranslateCacheRepository : CacheRepository<Translation, int, (string, LanguageENUM)>
{
    public TranslateCacheRepository(TBDatabaseContext databaseContext) : base(databaseContext)
    {

    }

    public override async Task CreateDictionaryByKey()
    {
        await InitAsync();

        if (cachedEnts.Count > 0)
        {
            cachedDictionary = cachedEnts.ToDictionary(x => (x.Key, x.LanguageId));
        }
        else 
        {
            cachedDictionary = new Dictionary<(string, LanguageENUM), Translation>();
        }
    }

    public override Translation GetByKeyOrDefault((string, LanguageENUM) key)
    {
        if (cachedDictionary.ContainsKey(key))
        {
            return cachedDictionary[key];
        }

        return null!;
    }
}
