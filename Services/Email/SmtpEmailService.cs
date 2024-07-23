using EmailSenderProgram.EmailSenders;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSenderProgram.Services.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly AppConfiguration _configuration;
        public SmtpEmailService(AppConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException();
            _configuration = configuration;
        }
        public async Task SendAsync(string to, string from, string subject, string body)
        {
            if (_configuration.IsDebugMode)
            {
                Console.WriteLine("Send mail to:" + to);
            }
            else
            {
                try
                {
                    using (var smtpClient = new SmtpClient(_configuration.EmailHost))
                    {
                        smtpClient.Port = _configuration.Port;
                        smtpClient.Credentials = new NetworkCredential(_configuration.UserName, _configuration.Password);
                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress(from),
                            Subject = subject,
                            Body = body,
                            IsBodyHtml = true
                        };
                        mailMessage.To.Add(to);

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email to {to}: {ex.Message}");
                }
            }
        }
    }
}
