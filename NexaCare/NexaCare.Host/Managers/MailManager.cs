using NexaCare.Host.Shared;

namespace NexaCare.Host.Managers;

public class MailManager
{
    public string GenerateForgotPasswordBody(string userName, string resetLink)
    {
        var body = MailBodies.ForgotPassword
            .Replace("{UserName}", userName)
            .Replace("{ResetLink}", resetLink);
        
        return body;
    }
}