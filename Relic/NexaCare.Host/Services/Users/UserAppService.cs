using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NexaCare.Database.EntityFrameworkCore;
using NexaCare.Database.Shared.Identity;
using NexaCare.Host.Dto.Roles;
using NexaCare.Host.Dto.Users;
using NexaCare.Host.ObjectMapper;
using NexaCare.Host.Services.Interfaces;

namespace NexaCare.Host.Services.Users;

public class UserAppService : IUserAppService
{
    private readonly UserManager<ApplicationUser>  _userManager;
    private readonly NexaCareDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public UserAppService(UserManager<ApplicationUser> userManager,
        NexaCareDbContext dbContext,
        IMapper mapper)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserById(string id)
    {
        var appUser = await _userManager.FindByIdAsync(id);

        if (appUser is null) return new UserDto();
        var roles = await _userManager.GetRolesAsync(appUser);
                
        var userDto = _mapper.Map<UserDto>(appUser);
        userDto.Roles.AddRange(roles);

        return userDto;
    }
}