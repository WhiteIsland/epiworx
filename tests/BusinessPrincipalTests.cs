using System;
using System.Security;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Epiworx.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epiworx.Tests
{
    [TestClass]
    public class BusinessPrincipalTests
    {
        public BusinessPrincipalTests()
        {
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Logon_As_Guest()
        {
            BusinessPrincipal.Login();

            Assert.IsTrue(Csla.ApplicationContext.User is BusinessPrincipal, "User context is not of type SalesSky.Security.BusinessPrincipal");
        }

        [TestMethod]
        public void Logon_With_Bad_UserName_And_Bad_Password()
        {
            try
            {
                BusinessPrincipal.Login("badusername", "badpassword");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is SecurityException);
            }
        }

        [TestMethod]
        public void Logon_With_Bad_UserName_And_Good_Password()
        {
            try
            {
                BusinessPrincipal.Login("badusername", "goodpassword");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is SecurityException);
            }
        }

        [TestMethod]
        public void Logon_With_Good_UserName_And_Bad_Password()
        {
            try
            {
                BusinessPrincipal.Login("goodusername", "badpassword");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is SecurityException);
            }
        }
    }
}
