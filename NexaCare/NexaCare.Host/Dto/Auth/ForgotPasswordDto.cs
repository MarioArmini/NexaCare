using System.ComponentModel.DataAnnotations;

namespace NexaCare.Host.Dto.Auth;

public class ForgotPasswordDto
{
    [Required]
    public required string Email { get; set; }
}