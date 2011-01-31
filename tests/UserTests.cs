using System;
using System.Collections.Generic;
using System.Data;
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
    public class UserTests
    {
        public UserTests()
        {
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void User_New()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            Assert.IsTrue(user.IsNew, "IsNew should be true");
            Assert.IsTrue(user.IsDirty, "IsDirty should be true");
            Assert.IsFalse(user.IsValid, "IsValid should be false");
            Assert.IsTrue(user.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(user.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(user.IsActive, "IsActive should be true");
            Assert.IsFalse(user.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "Name"),
                "Name should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "FirstName"),
                "FirstName should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "LastName"),
                "LastName should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "Password"),
                "Password should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(user, DbType.String, "Salt"),
                "Salt should be required");
            Assert.IsTrue(ValidationHelper.ContainsRule(user, "rule://epiworx.business.rolerequired/Role"),
                "Role should be required");
        }

        [TestMethod]
        public void User_New_Sign_Up()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            Assert.IsTrue(user.IsValid, "IsValid should be true");

            user = UserService.UserSave(user, null);

            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void User_New_Sign_Up_With_Duplicate_Name()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var name = DataHelper.RandomString(20);

            user.Name = name;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            UserService.UserSave(user, new EmptyMessenger());

            user = UserService.UserNew();

            user.Name = name;
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            Assert.IsTrue(ValidationHelper.ContainsRule(user, "rule://epiworx.business.userduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void User_New_Sign_Up_With_Duplicate_Email()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();
            var email = DataHelper.RandomEmail();

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = email;
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            UserService.UserSave(user, new EmptyMessenger());

            user = UserService.UserNew();

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = email;
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            Assert.IsTrue(ValidationHelper.ContainsRule(user, "rule://epiworx.business.userduplicateemailcheck/Email"),
                "Email should not be duplicated");
        }

        [TestMethod]
        public void User_New_Sign_Up_And_Send_Email()
        {
            BusinessPrincipal.Login();

            var user = UserService.UserNew();

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(DataHelper.RandomString(10));

            Assert.IsTrue(user.IsValid, "IsValid should be true");

            user = UserService.UserSave(user, MessengerHelper.InitMessengerForUserCreate());

            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void User_New_Sign_Up_And_Validate_Login_And_Password()
        {
            BusinessPrincipal.Login();

            var password = DataHelper.RandomString(10);
            var user = UserService.UserNew();

            user.Name = DataHelper.RandomString(20);
            user.FirstName = DataHelper.RandomString(20);
            user.LastName = DataHelper.RandomString(20);
            user.Email = DataHelper.RandomEmail();
            user.Role = Role.FullControl;

            user.SetPassword(password);

            user = UserService.UserSave(user, MessengerHelper.InitMessengerForUserCreate());

            BusinessPrincipal.Logout();

            BusinessPrincipal.Login(user.Name, password);

            var identity = (BusinessIdentity)Csla.ApplicationContext.User.Identity;

            Assert.IsTrue(identity.IsAuthenticated && identity.Name == user.Name);
        }

        [TestMethod]
        public void User_Edit()
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

            var userName = user.Name;

            user.Name = DataHelper.RandomString(20);

            user = UserService.UserSave(user, MessengerHelper.InitMessengerForUserCreate());

            user = UserService.UserFetch(user.UserId);

            Assert.IsTrue(user.Name != userName);
        }

        [TestMethod]
        public void User_Edit_As_Same_User()
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

            user = UserService.UserFetch(user.Name);

            var firstName = user.FirstName;

            user.FirstName = DataHelper.RandomString(10);

            user = UserService.UserSave(user, new EmptyMessenger());

            user = UserService.UserFetch(user.Name);

            Assert.IsTrue(user.FirstName != firstName);
        }
    }
}
