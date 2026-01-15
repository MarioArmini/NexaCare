using NexaCare.Host.Dto.Users;

namespace NexaCare.Host.Services.Interfaces;

public interface IUserAppService
{
    Task<UserDto> GetUserById(string id);
}