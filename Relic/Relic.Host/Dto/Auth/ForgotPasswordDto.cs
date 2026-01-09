using System.ComponentModel.DataAnnotations;

namespace Relic.Host.Dto.Auth;

public class ForgotPasswordDto
{
    [Required]
    public required string Email { get; set; }
}