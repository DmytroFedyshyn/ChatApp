using ChatApp.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace ChatApp.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("ChatApp", _configuration["EmailSettings:FromEmail"]));
            email.To.Add(new MailboxAddress(to, to));
            email.Subject = subject;

            email.Body = new TextPart("html") { Text = body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:SmtpPort"]), true);
            await smtp.AuthenticateAsync(_configuration["EmailSettings:SmtpUsername"], _configuration["EmailSettings:SmtpPassword"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
