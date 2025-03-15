using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EShop.Services;

public class EmailService(IOptions<MailSettings> options) : IEmailService
{
    private readonly MailSettings _mailOptions = options.Value;

    public async Task SendEmailAsync(string email, string subject, string templateName, Dictionary<string, string> templateModel)
    {
        using StreamReader streamReader = new($"{Directory.GetCurrentDirectory()}/Templates/{templateName}.html");
        string content = streamReader.ReadToEnd();
        streamReader.Close();

        foreach (var item in templateModel)
            content = content.Replace(item.Key, item.Value);

        await SendEmailAsync(email, subject, content);
    }

    private async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_mailOptions.Email),
            Subject = subject,
        };
        message.To.Add(MailboxAddress.Parse(email));

        var builder = new BodyBuilder { HtmlBody = htmlMessage };

        message.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        smtp.Connect(_mailOptions.Host, _mailOptions.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailOptions.Email, _mailOptions.Password);
        await smtp.SendAsync(message);
        smtp.Disconnect(true);
    }
}
