using Relic.Host.Dto.Users;

namespace Relic.Host.Services.Interfaces;

public interface IUserAppService
{
    Task<UserDto> GetUserById(string id);
}