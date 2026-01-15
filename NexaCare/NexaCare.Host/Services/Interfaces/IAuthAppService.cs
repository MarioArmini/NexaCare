using NexaCare.Database.Shared.Identity;
using NexaCare.Host.Dto.Auth;

namespace NexaCare.Host.Services.Interfaces;

public interface IAuthAppService
{
    Task RegisterAsync(RegisterDto input);
    Task<string> Login(LoginDto input);
    Task<string> ForgotPassword(ForgotPasswordDto input);
    Task<bool> ResetPassword(ResetPasswordDto input);
    Task AssignRoleAsync(Guid userId, string role);
}