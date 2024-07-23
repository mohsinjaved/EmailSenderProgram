using EmailSenderProgram.Services.Templates;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSenderProgram.EmailSenders
{

    public abstract class BaseEmailSender : IBaseEmailSender
    {
        protected readonly IEmailService _emailService;
        protected readonly AppConfiguration _configuration;
        protected readonly ITemplateService _templateService;


        public BaseEmailSender(IEmailService emailService, AppConfiguration configuration, ITemplateService templateService)
        {
            _emailService = emailService;
            _configuration = configuration;
            _templateService = templateService;
        }

        public virtual async Task<EmailSendResult> SendEmailAsync()
        {
            var result = new EmailSendResult();

            foreach (Customer recipient in GetRecipients())
            {
                try
                {
                    await _emailService.SendAsync(
                        recipient.Email,
                        _configuration.FromEmail,
                        GetEmailSubject(),
                        GetEmailBody(recipient)
                    );

                    result.AddSuccess(recipient);
                }
                catch (Exception ex)
                {
                    result.AddFailure(recipient);
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }

        protected abstract List<Customer> GetRecipients();
        protected abstract string GetEmailSubject();
        protected abstract string GetEmailBody(Customer customer);
    }


}
