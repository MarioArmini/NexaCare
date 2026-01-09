using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Relic.Database.EntityFrameworkCore;
using Relic.Database.Shared.Identity;
using Relic.Host.Dto.Roles;
using Relic.Host.Dto.Users;
using Relic.Host.ObjectMapper;
using Relic.Host.Services.Interfaces;

namespace Relic.Host.Services.Users;

public class UserAppService : IUserAppService
{
    private readonly UserManager<ApplicationUser>  _userManager;
    private readonly RelicDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public UserAppService(UserManager<ApplicationUser> userManager,
        RelicDbContext dbContext,
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