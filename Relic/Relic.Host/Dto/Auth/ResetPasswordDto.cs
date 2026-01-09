using System.ComponentModel.DataAnnotations;

namespace Relic.Host.Dto.Auth;

public class ResetPasswordDto
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Token { get; set; }
    [Required]
    public required string NewPassword { get; set; }
}