using System.Net;
using System.Net.Mail;
using NexaCare.Host.Services.Interfaces;

namespace NexaCare.Host.Services.Mails;

public class MailAppService : IMailAppService
{
    private readonly IConfiguration _config;
    private string SMTP_HOST;
    private int SMTP_PORT;
    private string SMTP_USERNAME;
    private string SMTP_PASSWORD;
    private string FROM;

    public MailAppService(IConfiguration config)
    {
        _config = config;
        
        SMTP_HOST = _config["Smtp:Host"];
        SMTP_PORT = int.Parse(_config["Smtp:Port"]);
        SMTP_USERNAME = _config["Smtp:Username"];
        SMTP_PASSWORD = _config["Smtp:Password"];
        FROM = _config["Smtp:From"];
    }

    public async Task SendMailAsync(string to, List<string>? ccs, List<string>? bccs, string subject, string body)
    {
        var client = new SmtpClient(SMTP_HOST, SMTP_PORT)
        {
            Credentials = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD),
            EnableSsl = true,
            UseDefaultCredentials = false
        };

        var mail = new MailMessage();
        mail.From = new MailAddress(FROM);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        if (bccs is { Count: > 0 })
        {
            foreach (var bcc in bccs)
                mail.Bcc.Add(bcc);
        }
        
        if (ccs is { Count: > 0 })
        {
            foreach (var cc in ccs)
                mail.CC.Add(cc);
        }

        await client.SendMailAsync(mail);
    }
}