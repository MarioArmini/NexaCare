namespace NexaCare.Host.Shared;

public static class MailBodies
{
    public const string ForgotPassword = @"
<html>
<body style=""font-family: Arial, sans-serif;"">

<p>Hi <b>{UserName}</b>,</p>

<p>
You requested a password update.<br/>
Click on the button below to proceed:
</p>

<p style=""margin:20px 0;"">
<a href=""{ResetLink}""
   style=""background:#2563eb;color:white;
          padding:12px 20px;
          text-decoration:none;
          border-radius:6px;"">
   Reset password
</a>
</p>

<p>— Nexus Identity team</p>

</body>
</html>";
}