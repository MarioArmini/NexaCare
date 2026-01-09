using Microsoft.AspNetCore.Mvc;
using Relic.Host.Dto.Users;
using Relic.Host.Services.Interfaces;

namespace Relic.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserAppService  _userAppService;

    public UsersController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpGet("Get/{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var user = await _userAppService.GetUserById(userId);
        
        return !string.IsNullOrEmpty(user.Id) ? Ok(user) : NotFound();
    }
}