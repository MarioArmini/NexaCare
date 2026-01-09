using Relic.Database.Shared.Identity;
using Relic.Host.Dto.Auth;

namespace Relic.Host.Services.Interfaces;

public interface IAuthAppService
{
    Task RegisterAsync(RegisterDto input);
    Task<string> Login(LoginDto input);
    Task<string> ForgotPassword(ForgotPasswordDto input);
    Task<bool> ResetPassword(ResetPasswordDto input);
    Task AssignRoleAsync(Guid userId, string role);
}