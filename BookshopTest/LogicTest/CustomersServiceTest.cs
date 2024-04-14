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

            Customer customer = DataGenerator.newCustomer();

            ID id = customers.add(customer);
            Assert.AreEqual(id, customers.getIds()[0]);

            Customer identicalCustomer = DataGenerator.copy(customer);
            Assert.ThrowsException<ItemAlreadyExists>(() => customers.add(identicalCustomer));

            Customer incorrect = DataGenerator.newCustomer();
            incorrect.LastName = "";

            Assert.ThrowsException<InvalidItemProperties>(() => customers.add(incorrect));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CustomersService customers = new CustomersService(storage);

            Customer customer = DataGenerator.newCustomer();
            ID id = customers.add(customer);

            Customer newCustomer = DataGenerator.copy(customer);
            newCustomer.FirstName = "John";
            customers.update(newCustomer);

            Assert.AreEqual(newCustomer.FirstName, customers.get(id).FirstName);

            customers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => customers.remove(id));
        }
    }
}
