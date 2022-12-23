namespace TB.Localization.Services;

public interface ILocalizationService
{
    Task<string> GetTranslateByInterface(string key, long userId);
}
