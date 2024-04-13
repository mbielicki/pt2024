using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.InMemoryStorage
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void testAddGet()
        {
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(null, firstName, lastName, address, contactInfo);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID customerId = storage.Customers.add(customer);
            Assert.AreEqual(customer.LastName, storage.Customers.get(c => c.Id == customerId).LastName);
        }

        [TestMethod]
        public void testRemove()
        {
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(null, firstName, lastName, address, contactInfo);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID customerId = storage.Customers.add(customer);
            storage.Customers.remove(customerId);
            Assert.IsNull(storage.Customers.get(c => c.Id == customerId));
        }

        [TestMethod]
        public void testUpdate()
        {
            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(null, firstName, lastName, address, contactInfo);

            IBookshopStorage storage = new InMemoryBookshopStorage();

            ID customerId = storage.Customers.add(customer);

            string newContactInfo = "john.doe@example.com";
            Customer newCustomer = new Customer(customerId, firstName, lastName, address, newContactInfo);

            storage.Customers.update(newCustomer);
            Assert.AreEqual(newContactInfo, storage.Customers.get(c => c.Id == customerId).ContactInfo);
        }
    }
}
