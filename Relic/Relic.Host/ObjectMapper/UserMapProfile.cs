using AutoMapper;
using Relic.Domain.Entities.Identity;
using Relic.Host.Dto.Users;

namespace Relic.Host.ObjectMapper;

public class UserMapProfile :  Profile
{
    public UserMapProfile()
    {
        CreateMap<User, UserDto>();
    }
}