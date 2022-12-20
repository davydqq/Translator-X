using TB.Database.Entities;
using TB.Database.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace TB.Database.Repositories;

public class UserSettingsRepository : Repository<UserSettings, int>
{
	public UserSettingsRepository(TBDatabaseContext databaseContext) : base(databaseContext)
	{

	}

	public Task<UserSettings?> GetSettingsIncludedLanguageTargetAsync(long userId)
	{
		return entities.Include(x => x.TargetLanguage).FirstOrDefaultAsync(x => x.TelegramUserId == userId);
	}

    public Task<UserSettings?> GetSettingsIncludeLanguageNativeAsync(long userId)
    {
        return entities.Include(x => x.NativeLanguage).FirstOrDefaultAsync(x => x.TelegramUserId == userId);
    }

    public Task<UserSettings?> GetSettingsIncludeTargetNativeLanguagesAsync(long userId)
    {
        return entities
            .Include(x => x.NativeLanguage)
            .Include(x => x.TargetLanguage)
            .FirstOrDefaultAsync(x => x.TelegramUserId == userId);
    }

    public Task<UserSettings?> GetLanguageInterfaceAsync(long userId)
    {
        return entities.Include(x => x.InterfaceLanguage).FirstOrDefaultAsync(x => x.TelegramUserId == userId);
    }
}
