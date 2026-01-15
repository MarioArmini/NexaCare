using AutoMapper;
using NexaCare.Domain.Entities.Identity;
using NexaCare.Host.Dto.Users;

namespace NexaCare.Host.ObjectMapper;

public class UserMapProfile :  Profile
{
    public UserMapProfile()
    {
        CreateMap<User, UserDto>();
    }
}