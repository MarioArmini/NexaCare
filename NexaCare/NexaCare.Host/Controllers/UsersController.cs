using Microsoft.AspNetCore.Mvc;
using NexaCare.Host.Dto.Users;
using NexaCare.Host.Services.Interfaces;

namespace NexaCare.Host.Controllers;

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