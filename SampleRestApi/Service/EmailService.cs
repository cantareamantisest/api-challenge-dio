using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SampleRestApi.Service.Interfaces;
using SampleRestApi.Utils;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Service
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(EmailViewModel request)
        {
            try
            {
                var config = ConfigurationOperations.ReadConfiguration();
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(MailboxAddress.Parse(config.SmtpServer.Username));
                mimeMessage.To.Add(MailboxAddress.Parse(request.To));
                mimeMessage.Subject = request.Subject;
                mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(config.SmtpServer.Host, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(config.SmtpServer.Username, config.SmtpServer.Password);
                smtp.Send(mimeMessage);
                smtp.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}