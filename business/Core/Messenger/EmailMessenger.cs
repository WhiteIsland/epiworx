using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Epiworx.Core.Messenger
{
    [Serializable]
    public class EmailMessenger : IEmailMessenger
    {
        public string Sender { get; set; }
        public List<string> Recipients { get; set; }
        public List<string> CcRecipients { get; set; }
        public List<string> BccRecipients { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpServerPort { get; set; }
        public bool EnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }

        public EmailMessenger()
        {
            this.SmtpServer = ConfigurationManager.AppSettings["MailSmtpServer"];
            this.SmtpServerPort = int.Parse(ConfigurationManager.AppSettings["MailSmtpServerPort"]);
            this.Sender = ConfigurationManager.AppSettings["MailFrom"];
            this.UserName = ConfigurationManager.AppSettings["MailUserName"];
            this.Password = ConfigurationManager.AppSettings["MailPassword"];
            this.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["MailSslEnabled"]);
            this.IsBodyHtml = true;

            this.Recipients = new List<string>();
            this.CcRecipients = new List<string>();
            this.BccRecipients = new List<string>();
        }

        public bool Send()
        {
            var message = new MailMessage();

            message.From = new MailAddress(this.Sender);

            foreach (var recipient in this.Recipients)
            {
                message.To.Add(recipient);
            }

            foreach (var recipient in this.CcRecipients)
            {
                message.CC.Add(recipient);
            }

            foreach (var recipient in this.BccRecipients)
            {
                message.Bcc.Add(recipient);
            }

            message.Subject = this.Subject;
            message.Body = this.Message;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = null;
            NetworkCredential credentials = null;

            smtpClient = new SmtpClient(this.SmtpServer, this.SmtpServerPort);

            credentials = new NetworkCredential(this.UserName, this.Password);

            smtpClient.EnableSsl = Convert.ToBoolean(this.EnableSsl);
            smtpClient.Credentials = credentials;

            smtpClient.Send(message);

            return true;
        }
    }
}
