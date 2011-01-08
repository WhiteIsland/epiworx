using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core.Helpers;
using Epiworx.Core.Messenger;
using Epiworx.Security;
using Epiworx.Security.Helpers;

namespace Epiworx.Service
{
    public class UserPasswordService
    {
        public static UserPassword UserPasswordReset(string name)
        {
            string password;

            return UserPasswordService.UserPasswordReset(name, out password, null);
        }

        public static UserPassword UserPasswordReset(string name, out string password, IMessenger messenger)
        {
            var user = UserPassword.FetchUserPassword(
                new UserPasswordCriteria
                    {
                        Name = name
                    });

            if (user != null)
            {
                password = PasswordHelper.GetRandomPassword(10);

                user.SetPassword(password);

                user = user.Save();

                if (messenger == null)
                {
                    messenger = MessageHelper.InitializeMessageForUserPasswordReset(user.Email);
                }

                messenger.Message = messenger.Message.Replace(MessageParameter.Password, password);

                messenger.Send();
            }
            else
            {
                throw new ArgumentException("No such user exists.");
            }

            return user;
        }

        public static bool UserPasswordChange(string newPassword, string confirmPassword)
        {
            return UserPasswordService.UserPasswordChange(newPassword, confirmPassword, null);
        }

        public static bool UserPasswordChange(string newPassword, string confirmPassword, IMessenger messenger)
        {
            if (!newPassword.Equals(confirmPassword))
            {
                throw new Csla.Rules.ValidationException("New password and confirmation password must be the same.");
            }

            var user = User.FetchUser(
                new UserCriteria
                    {
                        UserId = BusinessPrincipal.GetCurrentIdentity().UserId
                    });

            if (user != null)
            {
                var password = newPassword;

                user.SetPassword(password);

                user = user.Save();

                if (messenger == null)
                {
                    messenger = MessageHelper.InitializeMessageForUserPasswordChange(user.Email);
                }

                messenger.Message = messenger.Message.Replace(MessageParameter.Password, password);

                messenger.Send();
            }
            else
            {
                throw new ArgumentException("No such user exists.");
            }

            return true;
        }
    }
}
