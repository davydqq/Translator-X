using TB.Common;

namespace TB.User;

public interface IUserService
{
    Task<bool> ValidateThatUserSelectLanguages(BaseTelegramMessageCommand command);

    Task<bool> ValidateThatAudioLanguageSelected(BaseTelegramMessageCommand command);
}
