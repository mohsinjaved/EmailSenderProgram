using EmailSenderProgram.EmailSenders;
using EmailSenderProgram.Services.Email;
using EmailSenderProgram.Services.Templates;
using System;
using System.Threading.Tasks;
using static EmailSenderProgram.Enums;

namespace EmailSenderProgram
{
    internal class Program
    {
        /// <summary>
        /// This application is run everyday
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            //set configuration
            var configuration = AppConfiguration.GetInstance();
            
            //create dependencies
            IEmailService emailService = new SmtpEmailService(configuration);
            var templateService = new TemplateService(configuration.EmailTemplateFolderName);

            var welcomeEmailSender = EmailSenderFactory.CreateEmailSender(EmailType.Welcome, emailService, configuration, templateService);
            var welcomeEmailResult = await welcomeEmailSender.SendEmailAsync();

            EmailSendResult comebackEmailResult = null;

            //send comback email in case of debug mode or on sunday
            if (configuration.IsDebugMode || IsSunday())
            {
                var comebackEmailSender = EmailSenderFactory.CreateEmailSender(EmailType.Comeback, emailService, configuration, templateService, "EOComebackToUs");
                comebackEmailResult = await comebackEmailSender.SendEmailAsync();
            }

            if (welcomeEmailResult.IsSuccess() && (comebackEmailResult?.IsSuccess() ?? true))
            {
                Console.WriteLine("All mails are sent successfully.");
            }
            else
            {
                Console.WriteLine("Oops, something went wrong when sending mail.");
            }

            Console.ReadKey();
        }

        static bool IsSunday()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }

    }



}