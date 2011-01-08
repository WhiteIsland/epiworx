using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core.Messenger;

namespace Epiworx.Core.Messenger
{
    internal class MessageProvider
    {
        public MessageProvider InitMessenger()
        {
            var messenger = new EmailMessenger();

            messenger.SmtpServer = ConfigurationManager.AppSettings["MailSmtpServer"];
            messenger.SmtpServerPort = int.Parse(ConfigurationManager.AppSettings["MailSmtpServerPort"]);
            messenger.Sender = ConfigurationManager.AppSettings["MailFrom"];
            messenger.UserName = ConfigurationManager.AppSettings["MailUserName"];
            messenger.Password = ConfigurationManager.AppSettings["MailPassword"];
            messenger.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["MailSslEnabled"]);
            messenger.IsBodyHtml = true;

            return messenger;
        }

        public static IEmailMessenger InitMessengerForUserCreate(IUser user)
        {
            var messenger = MessengerService.InitMessenger();

            messenger.Subject = "Epiworx Notification - Welcome to Epiworx!";
            messenger.Message = string.Format("Welcome {0} to Epiworx! Your account has been successfully created!",
                user.Name);

            messenger.Recipients.Add(user.Email);

            return messenger;
        }
    }
}
