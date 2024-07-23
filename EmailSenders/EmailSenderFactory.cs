using EmailSenderProgram.Services.Templates;
using System;
using System.Collections.Generic;
using static EmailSenderProgram.Enums;

namespace EmailSenderProgram.EmailSenders
{
   
    public static class EmailSenderFactory
    {
        private static readonly Dictionary<EmailType, Func<object[], IBaseEmailSender>> _emailSenders =
            new Dictionary<EmailType, Func<object[], IBaseEmailSender>>
            {
                { EmailType.Welcome, args => new WelcomeEmailSender((IEmailService)args[0], (AppConfiguration)args[1],(ITemplateService)args[2]) },
                { EmailType.Comeback, args => new ComebackEmailSender((IEmailService)args[0], (AppConfiguration)args[1],(ITemplateService)args[2], args.Length > 3 ? args[3] as string : null) }
            };

        public static IBaseEmailSender CreateEmailSender(EmailType type, params object[] args)
        {
            if (_emailSenders.TryGetValue(type, out var createSender))
            {
                return createSender(args);
            }

            throw new ArgumentException("Invalid email type");
        }
    }





}
