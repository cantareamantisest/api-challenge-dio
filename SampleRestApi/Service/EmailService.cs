using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SampleRestApi.Data;
using SampleRestApi.Service.Interfaces;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Service
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext _context;

        public EmailService(AppDbContext context)
        {
            _context = context;
        }

        public bool SendEmail(EmailViewModel request)
        {
            try
            {
                var config = _context.AppSettings.AsNoTracking().FirstOrDefault(c => c.Id > 0);
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(MailboxAddress.Parse(config?.Username));
                mimeMessage.To.Add(MailboxAddress.Parse(request.To));
                mimeMessage.Subject = request.Subject;
                mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(config?.Hostname, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(config?.Username, config?.Password);
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