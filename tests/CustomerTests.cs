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
    public class CustomerTests
    {
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }

        public CustomerTests()
        {

        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            CustomerTests.UserName = DataHelper.RandomString(20);
            CustomerTests.UserPassword = DataHelper.RandomString(20);

            BusinessHelper.CreateUserWithFullControl(
                CustomerTests.UserName,
                CustomerTests.UserPassword);
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login(
                CustomerTests.UserName,
                CustomerTests.UserPassword);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Customer_New()
        {
            var customer = CustomerService.CustomerNew();

            Assert.IsTrue(customer.IsNew, "IsNew should be true");
            Assert.IsTrue(customer.IsDirty, "IsDirty should be true");
            Assert.IsFalse(customer.IsValid, "IsValid should be false");
            Assert.IsTrue(customer.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(customer.IsSelfValid, "IsSelfValid should be false");
            Assert.IsTrue(customer.IsActive, "IsActive should be true");
            Assert.IsFalse(customer.IsArchived, "IsArchived should be false");

            Assert.IsTrue(ValidationHelper.ContainsRule(customer, DbType.String, "Name"),
                "Name should be required");
        }

        [TestMethod]
        public void Customer_Add()
        {
            var customer = CustomerService.CustomerNew();

            customer.Name = DataHelper.RandomString(20);

            Assert.IsTrue(customer.IsValid, "IsValid should be true");

            CustomerService.CustomerSave(customer);
        }

        [TestMethod]
        public void Customer_Add_With_Duplicate_Name()
        {
            var customer = CustomerService.CustomerNew();
            var name = DataHelper.RandomString(20);

            customer.Name = name;

            CustomerService.CustomerSave(customer);

            customer = CustomerService.CustomerNew();

            customer.Name = name;

            Assert.IsTrue(ValidationHelper.ContainsRule(customer, "rule://epiworx.business.customerduplicatenamecheck/Name"),
                "Name should not be duplicated");
        }

        [TestMethod]
        public void Customer_Edit()
        {
            var customer = CustomerService.CustomerNew();
            var name = DataHelper.RandomString(20);

            customer.Name = name;

            customer = CustomerService.CustomerSave(customer);

            customer = CustomerService.CustomerFetch(customer.CustomerId);

            customer.Name = DataHelper.RandomString(20);

            customer = CustomerService.CustomerSave(customer);

            customer = CustomerService.CustomerFetch(customer.CustomerId);

            Assert.IsTrue(customer.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Customer_Delete()
        {
            var customer = CustomerService.CustomerNew();

            customer.Name = DataHelper.RandomString(20);

            customer = CustomerService.CustomerSave(customer);

            customer = CustomerService.CustomerFetch(customer.CustomerId);

            CustomerService.CustomerDelete(customer.CustomerId);

            try
            {
                CustomerService.CustomerFetch(customer.CustomerId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }

        [TestMethod]
        public void Customer_Fetch()
        {
            var customer = CustomerService.CustomerNew();

            customer.Name = DataHelper.RandomString(20);

            customer = CustomerService.CustomerSave(customer);

            customer = CustomerService.CustomerFetch(customer.CustomerId);

            Assert.IsFalse(customer == null, "Customer should not be null");
        }

        [TestMethod]
        public void Customer_Fetch_List()
        {
            var customer = CustomerService.CustomerNew();

            customer.Name = DataHelper.RandomString(20);

            customer = CustomerService.CustomerSave(customer);

            customer.Name = DataHelper.RandomString(20);

            CustomerService.CustomerSave(customer);

            var customers = CustomerService.CustomerFetchInfoList();

            Assert.IsTrue(customers.Count > 1, "Customers should be greater than one");
        }
    }
}
