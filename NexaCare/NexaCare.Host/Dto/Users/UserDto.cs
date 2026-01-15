using NexaCare.Host.Dto.Roles;

namespace NexaCare.Host.Dto.Users;

public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}