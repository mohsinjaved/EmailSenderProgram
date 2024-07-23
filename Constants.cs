using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
    public static class Constants
    {
        public static class EmailTemplates
        {
            public static readonly string ComeBackEmail = "ComeBackEmail.cshtml";
            public static readonly string WelocomEmail = "WelocomEmail.cshtml";
        }
        public static class ConfigurationKeys
        {
            public static readonly string FromEmail = "FromEmail";
            public static readonly string IsDebugMode = "IsDebugMode";
            public static readonly string EmailHost = "EmailHost";
            public static readonly string Port = "Port";
            public static readonly string UserName = "UserName";
            public static readonly string Password = "Password";
            public static readonly string EmailTemplateFolderName = "EmailTemplateFolderName";
        }
        
    }
}
