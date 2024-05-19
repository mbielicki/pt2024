using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Data.Database;

namespace BookshopTest.DataTest.DatabaseTest
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IDataLayer storage = new DatabaseBookshopStorage();

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = storage.Customers.add(customer);

            Assert.AreEqual(customer.LastName, storage.Customers.get(c => c.Id.Equals(customerId)).LastName);

            storage.Customers.remove(customerId);
        }

        [TestMethod]
        public void testRemove()
        {
            IDataLayer storage = new DatabaseBookshopStorage();

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = storage.Customers.add(customer);

            storage.Customers.remove(customerId);

            Assert.IsNull(storage.Customers.get(c => c.Id.Equals(customerId)));
        }

        [TestMethod]
        public void testUpdate()
        {
            IDataLayer storage = new DatabaseBookshopStorage();

            ICustomer customer = DataGenerator.newCustomer();
            int customerId = storage.Customers.add(customer);

            ICustomer newCustomer = DataGenerator.copy(customer);
            newCustomer.ContactInfo = "john.doe@example.com";

            storage.Customers.update(newCustomer);
            Assert.AreEqual(newCustomer.ContactInfo, storage.Customers.get(c => c.Id.Equals(customerId)).ContactInfo);

            storage.Customers.remove(customerId);
        }
    }
}
