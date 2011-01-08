using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core.Messenger;

namespace Epiworx.Tests.Helpers
{
    public class MessengerHelper
    {
        public static IEmailMessenger InitMessengerForUserCreate()
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Welcome to Epiworx!";
            messenger.Message = "Welcome to Epiworx! Your account has been successfully created!";
            messenger.Recipients.Add("mattruma@gmail.com");

            return messenger;
        }

        public static IEmailMessenger InitMessengerForUserEdit()
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your user profile was updated";
            messenger.Message = "Your account has been successfully updated!";
            messenger.Recipients.Add("mattruma@gmail.com");

            return messenger;
        }

        public static IEmailMessenger InitMessengerForUserUpdatePassword()
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your password was changed";
            messenger.Message = "Your password for you account has been successfully changed!";
            messenger.Recipients.Add("mattruma@gmail.com");

            return messenger;
        }

        public static IEmailMessenger InitMessengerForUserResetPassword(string password)
        {
            var messenger = new EmailMessenger();

            messenger.Subject = "Epiworx Notification - Your password was reset";
            messenger.Message = string.Format(
                "Your password for you account has been successfully reset to {0}!", password);
            messenger.Recipients.Add("mattruma@gmail.com");

            return messenger;
        }
    }
}
