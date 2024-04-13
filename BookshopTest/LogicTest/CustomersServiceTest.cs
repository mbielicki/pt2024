using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Customers;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class CustomersServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CustomersService customers = new CustomersService(storage);

            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(null, firstName, lastName, address, contactInfo);

            ID id = customers.add(customer);
            Assert.AreEqual(id, customers.get(id).Id);

            Customer identicalCustomer = new Customer(null, firstName, lastName, address, contactInfo);
            Assert.ThrowsException<ItemAlreadyExists>(() => customers.add(identicalCustomer));

            Customer incorrect = new Customer(null, firstName, "", address, contactInfo);
            Assert.ThrowsException<InvalidItemProperties>(() => customers.add(incorrect));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CustomersService customers = new CustomersService(storage);

            string firstName = "John";
            string lastName = "Doe";
            string address = "00000 Baker Street 221B, London, England";
            string? contactInfo = null;

            Customer customer = new Customer(null, firstName, lastName, address, contactInfo);
            ID id = customers.add(customer);

            Customer newCustomer = new Customer(id, "Joan", lastName, address, contactInfo);
            customers.update(newCustomer);
            Assert.AreEqual(newCustomer.FirstName, customers.get(id).FirstName);

            customers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => customers.remove(id));
        }
    }
}
