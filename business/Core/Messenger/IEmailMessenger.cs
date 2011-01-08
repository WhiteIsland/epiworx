using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Epiworx.Core.Messenger
{
    public interface IEmailMessenger : IMessenger
    {
        string Sender { get; set; }
        List<string> Recipients { get; set; }
        List<string> CcRecipients { get; set; }
        List<string> BccRecipients { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Subject { get; set; }
        string SmtpServer { get; set; }
        int SmtpServerPort { get; set; }
        bool EnableSsl { get; set; }
        bool IsBodyHtml { get; set; }
    }
}
