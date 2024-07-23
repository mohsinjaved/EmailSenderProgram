using EmailSenderProgram.Services.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmailSenderProgram.Constants;

namespace EmailSenderProgram.EmailSenders
{
    /// <summary>
    /// Sends Welcome mail
    /// </summary>
    /// <returns>bool</returns>
    public class WelcomeEmailSender : BaseEmailSender
    {
        public WelcomeEmailSender(IEmailService emailService,
            AppConfiguration configuration,
            ITemplateService templateService)
            : base(emailService, configuration, templateService)
        {

        }

        public override async Task<EmailSendResult> SendEmailAsync()
        {
            Console.WriteLine("Send Welcome email");
            return await base.SendEmailAsync();
        }

        protected override List<Customer> GetRecipients()
        {
            //filter newly registered customers, one day back in time
            return DataLayer.ListCustomers()
                .Where(c => c.CreatedDateTime == DateTime.Now.AddDays(-1))
                .ToList();
        }

        protected override string GetEmailBody(Customer customer)
        {
            //using email in Template because customer do not have name property
            var model = new { customer.Email};
            return _templateService.RenderTemplate(EmailTemplates.WelocomEmail, model);
        }

        protected override string GetEmailSubject()
        {
            return "Welcome as a new customer at EO!";
        }
    }
}
