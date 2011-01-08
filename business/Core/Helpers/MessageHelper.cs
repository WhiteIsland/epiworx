using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core.Messenger;

namespace Epiworx.Core.Helpers
{
    internal class MessageHelper
    {
        public static IEmailMessenger InitializeMessageForUserCreate(string email)
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Welcome to Epiworx!";
            messenger.Message = string.Format("Welcome <b>{0}</b> to Epiworx! Your account has been successfully created!",
                MessageParameter.UserName);

            messenger.Recipients.Add(email);

            return messenger;
        }

        public static IEmailMessenger InitializeMessageForUserEdit(string email)
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your user profile was updated";
            messenger.Message = "Your account has been successfully updated!";

            messenger.Recipients.Add(email);

            return messenger;
        }

        public static IEmailMessenger InitializeMessageForUserPasswordChange(string email)
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your password was changed";
            messenger.Message = "Your password for you account has been successfully changed!";

            messenger.Recipients.Add(email);

            return messenger;
        }

        public static IEmailMessenger InitializeMessageForUserPasswordReset(string email)
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your password was reset";
            messenger.Message = string.Format(
                "Your password for you account has been successfully reset to {0}!", MessageParameter.Password);

            messenger.Recipients.Add(email);

            return messenger;
        }
    }
}
