using System.ComponentModel.DataAnnotations;

namespace NexaCare.Host.Dto.Auth;

public class LoginDto
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}