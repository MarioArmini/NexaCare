using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Relic.Host.Dto.Auth;
using Relic.Host.Services.Interfaces;

namespace Relic.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthAppService  _authAppService;

    public AuthController(IAuthAppService authAppService)
    {
        _authAppService = authAppService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            await _authAppService.RegisterAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authAppService.Login(dto);
        
        if (string.IsNullOrEmpty(token))
            return Unauthorized();
        
        return Ok(new { token });
    }

    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        var token = await _authAppService.ForgotPassword(dto);
        
        if (string.IsNullOrEmpty(token))
            return Unauthorized();
        
        return Ok(new { token });
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        var result = await _authAppService.ResetPassword(dto);
        if (!result)
            return BadRequest();
        return Ok();
    }
}