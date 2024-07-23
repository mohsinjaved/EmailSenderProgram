using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSenderProgram.EmailSenders
{
    public interface IBaseEmailSender
    {
        Task<EmailSendResult> SendEmailAsync();
    }
}
