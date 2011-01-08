using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Epiworx.Business;
using Epiworx.Service;
using Epiworx.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epiworx.Security;

namespace Epiworx.Tests
{
    [TestClass]
    public class UserPasswordTests
    {
        public UserPasswordTests()
        {
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void User_Password_Change_Password()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var password = DataHelper.RandomString(10);

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            user = UserService.UserSave(user, new EmptyMessenger());

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(user.Name, password);

            user = UserService.UserFetch(user.UserId);

            user.SetPassword(DataHelper.RandomString(20));

            var newPassword = DataHelper.RandomString(20);

            UserPasswordService.UserPasswordChange(newPassword, newPassword, new EmptyMessenger());

            user = UserService.UserFetch(user.UserId);

            Assert.IsTrue(user.Password != password);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(user.Name, newPassword);
        }

        [TestMethod]
        public void User_Password_Change_Password_And_Send_Message()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var password = DataHelper.RandomString(10);

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            user = UserService.UserSave(user, new EmptyMessenger());

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(user.Name, password);

            user = UserService.UserFetch(user.UserId);

            user.SetPassword(DataHelper.RandomString(20));

            var newPassword = DataHelper.RandomString(20);

            UserPasswordService.UserPasswordChange(newPassword, newPassword, MessengerHelper.InitMessengerForUserUpdatePassword());

            user = UserService.UserFetch(user.UserId);

            Assert.IsTrue(user.Password != password);

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(user.Name, newPassword);
        }

        [TestMethod]
        public void User_Password_Reset_Password()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            user.Name = name;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            UserService.UserSave(user, new EmptyMessenger());

            BusinessPrincipal.Login(name, password);

            BusinessPrincipal.Logout();

            string newPassword;

            UserPasswordService.UserPasswordReset(name, out newPassword, new EmptyMessenger());

            BusinessPrincipal.Login(name, newPassword);

            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void User_Password_Reset_Password_And_Send_Message()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var name = DataHelper.RandomString(20);
            var password = DataHelper.RandomString(20);

            user.Name = name;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            user = UserService.UserSave(user, new EmptyMessenger());

            UserService.UserFetch(user.UserId);

            BusinessPrincipal.Login(name, password);

            BusinessPrincipal.Logout();

            string newPassword;

            UserPasswordService.UserPasswordReset(name, out newPassword, MessengerHelper.InitMessengerForUserUpdatePassword());

            BusinessPrincipal.Login(name, newPassword);

            BusinessPrincipal.Logout();
        }
    }
}
