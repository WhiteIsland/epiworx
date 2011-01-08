using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Core.Helpers;
using Epiworx.Core.Messenger;

namespace Epiworx.Service
{
    [Serializable]
    public class UserService
    {
        public static User UserFetch(int userId)
        {
            return User.FetchUser(
                new UserCriteria
                    {
                        UserId = userId
                    });
        }

        public static User UserFetch(string name)
        {
            return User.FetchUser(
                new UserCriteria
                {
                    Name = name
                });
        }

        public static UserInfoList UserFetchInfoList()
        {
            return UserService.UserFetchInfoList(
                new UserCriteria());
        }

        internal static UserInfoList UserFetchInfoList(UserCriteria criteria)
        {
            return UserInfoList.FetchUserInfoList(criteria);
        }

        public static User UserSave(User user)
        {
            return UserService.UserSave(user, null);
        }

        public static User UserSave(User user, IMessenger messenger)
        {
            if (!user.IsValid)
            {
                return user;
            }

            User result;

            if (user.IsNew)
            {
                result = UserService.UserInsert(user, messenger);
            }
            else
            {
                result = UserService.UserUpdate(user, messenger);
            }

            return result;
        }

        public static User UserInsert(User user, IMessenger messenger)
        {
            var result = user.Save();

            if (messenger == null)
            {
                messenger = MessageHelper.InitializeMessageForUserCreate(user.Email);
            }

            messenger.Message = messenger.Message.Replace(MessageParameter.UserName, user.Name);

            messenger.Send();

            return result;
        }

        public static User UserUpdate(User user, IMessenger messenger)
        {
            var result = user.Save();

            if (messenger == null)
            {
                messenger = MessageHelper.InitializeMessageForUserEdit(user.Email);
            }

            messenger.Message = messenger.Message.Replace(MessageParameter.UserName, user.Name);

            messenger.Send();

            return result;
        }

        public static User UserNew()
        {
            return User.NewUser();
        }

        public static bool UserDelete(User user)
        {
            User.DeleteUser(
                new UserCriteria
                    {
                        UserId = user.UserId
                    });

            return true;
        }

        public static bool UserDelete(int userId)
        {
            return UserService.UserDelete(
                UserService.UserFetch(userId));
        }
    }
}