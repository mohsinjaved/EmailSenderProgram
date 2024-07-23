using EmailSenderProgram.Models;
using EmailSenderProgram.Services.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmailSenderProgram.Constants;

namespace EmailSenderProgram.EmailSenders
{
    /// <summary>
    /// Send comeback mail
    /// </summary>
    /// <returns>bool</returns>
    public class ComebackEmailSender : BaseEmailSender
    {
        private readonly string _voucherCode;
        
        public ComebackEmailSender(
            IEmailService emailService,
            AppConfiguration configuration,
            ITemplateService templateService,
        string voucherCode
        ) : base(emailService, configuration,templateService)
        {
            _voucherCode = voucherCode;
        }
        public override async Task<EmailSendResult> SendEmailAsync()
        {
            Console.WriteLine("Send Comeback Email");
            return await base.SendEmailAsync();
        }

        protected override List<Customer> GetRecipients()
        {
            //filter customer hasn't put an order
            var orders = DataLayer.ListOrders();
            var customers = DataLayer.ListCustomers();
            return customers
                .Where(customer => !orders.Any(order => order.CustomerEmail == customer.Email))
                .ToList();
        }

        protected override string GetEmailBody(Customer customer)
        {
            //use strongly typed model instead of anonymous object in case of complex model
            var model = new ComebackEmailModel(customer.Email, _voucherCode);
            return _templateService.RenderTemplate(EmailTemplates.ComeBackEmail, model);
        }

        protected override string GetEmailSubject()
        {
            return "We miss you as a customer";
        }
    }

}
