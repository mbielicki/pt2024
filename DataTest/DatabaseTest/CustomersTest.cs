﻿using Data.API;
using Data.Model.Entities;
using BookshopTest.Data.Database;
using Data.Database;
using DataTest;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = dataLayer.Customers.add(customer);

            Assert.AreEqual(customer.LastName, dataLayer.Customers.get(c => c.Id.Equals(customerId)).LastName);

            dataLayer.Customers.remove(customerId);
        }

        [TestMethod]
        public void testRemove()
        {
            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = dataLayer.Customers.add(customer);

            dataLayer.Customers.remove(customerId);

            Assert.IsNull(dataLayer.Customers.get(c => c.Id.Equals(customerId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            IDataLayer dataLayer = new DatabaseDataLayer(TestConnectionString.Get());

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = dataLayer.Customers.add(customer);

            ICustomer newCustomer = DataGenerator.copy(customer);
            newCustomer.ContactInfo = "john.doe@example.com";

            dataLayer.Customers.update(newCustomer);
            Assert.AreEqual(newCustomer.ContactInfo, dataLayer.Customers.get(c => c.Id.Equals(customerId)).ContactInfo);

            dataLayer.Customers.remove(customerId);
        }
    }
}
