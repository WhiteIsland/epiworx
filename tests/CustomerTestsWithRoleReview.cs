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
    public class CustomerTestsWithRoleReview
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public CustomerTestsWithRoleReview()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            CustomerTestsWithRoleReview.UserName = DataHelper.RandomString(20);
            CustomerTestsWithRoleReview.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithReview(
                CustomerTestsWithRoleReview.UserName,
                CustomerTestsWithRoleReview.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                CustomerTestsWithRoleReview.UserName,
                CustomerTestsWithRoleReview.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Customer_New()
        {
            Exception exception = null;

            try
            {
                CustomerService.CustomerNew();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Customer_Edit()
        {
            var customer = BusinessHelper.CreateCustomerAndLogon(
                CustomerTestsWithRoleReview.UserName,
                CustomerTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                customer = CustomerService.CustomerFetch(customer.CustomerId);

                customer.Name = DataHelper.RandomString(20);

                CustomerService.CustomerSave(customer);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Customer_Delete()
        {
            var customer = BusinessHelper.CreateCustomerAndLogon(
                 CustomerTestsWithRoleReview.UserName,
                 CustomerTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                CustomerService.CustomerDelete(customer.CustomerId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null, "Exception should not be null");
            Assert.IsTrue(exception.GetBaseException() is SecurityException);
        }

        [TestMethod]
        public void Customer_Fetch()
        {
            var customer = BusinessHelper.CreateCustomerAndLogon(
                 CustomerTestsWithRoleReview.UserName,
                 CustomerTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                CustomerService.CustomerFetch(customer.CustomerId);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }

        [TestMethod]
        public void Customer_Fetch_List()
        {
            BusinessHelper.CreateCustomerAndLogon(
                 CustomerTestsWithRoleReview.UserName,
                 CustomerTestsWithRoleReview.UserPassword);

            BusinessHelper.CreateCustomerAndLogon(
                 CustomerTestsWithRoleReview.UserName,
                 CustomerTestsWithRoleReview.UserPassword);

            Exception exception = null;

            try
            {
                CustomerService.CustomerFetchInfoList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception == null, "Exception should be null");
        }
    }
}
