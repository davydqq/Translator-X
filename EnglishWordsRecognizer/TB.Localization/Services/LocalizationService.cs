using TB.Database.Entities;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;

namespace TB.Localization.Services;

public class LocalizationService : ILocalizationService
{
    private readonly UserSettingsRepository userSettingsRepository;
    private readonly TranslateCacheRepository translateCacheRepository;

    public LocalizationService(
        UserSettingsRepository userSettingsRepository,
        TranslateCacheRepository translateCacheRepository)
    {
        this.userSettingsRepository = userSettingsRepository;
        this.translateCacheRepository = translateCacheRepository;
    }

    public async Task<string> GetTranslateByInterface(string key, long userId)
    {
        var settings = await userSettingsRepository.FirstOrDefaultAsync(x => x.TelegramUserId == userId);

        if (settings != null)
        {
            var interfaceLangId = settings.InterfaceLanguageId ?? LanguageENUM.English;
            var translate = translateCacheRepository.GetByKeyOrDefault((key, interfaceLangId));

            if (translate != null)
            {
                return translate.Translate;
            }
        }

        return null!;
    }
}
