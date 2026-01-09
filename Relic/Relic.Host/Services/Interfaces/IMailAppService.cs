namespace Relic.Host.Services.Interfaces;

public interface IMailAppService
{
    Task SendMailAsync(string to, List<string>? ccs, List<string>? bccs, string subject, string body);
}