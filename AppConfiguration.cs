using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static EmailSenderProgram.Constants;

namespace EmailSenderProgram.EmailSenders
{
    public class AppConfiguration
    {

        public string FromEmail { get; set; }
        public bool IsDebugMode { get; set; }
        public string EmailHost { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailTemplateFolderName { get; set; }
        
        private static readonly Lazy<AppConfiguration> lazyInstance =
        new Lazy<AppConfiguration>(() => new AppConfiguration());

        private AppConfiguration()
        {
            FromEmail = ConfigurationManager.AppSettings[ConfigurationKeys.FromEmail];
            IsDebugMode = bool.Parse(ConfigurationManager.AppSettings[ConfigurationKeys.IsDebugMode]);
            EmailHost = ConfigurationManager.AppSettings[ConfigurationKeys.EmailHost];
            Port = int.Parse(ConfigurationManager.AppSettings[ConfigurationKeys.Port]);
            UserName = ConfigurationManager.AppSettings[ConfigurationKeys.UserName];
            Password = ConfigurationManager.AppSettings[ConfigurationKeys.Password];
            EmailTemplateFolderName = ConfigurationManager.AppSettings[ConfigurationKeys.EmailTemplateFolderName];
        }

        public static AppConfiguration GetInstance()
        {
            return lazyInstance.Value;
        }

    }
   
}
