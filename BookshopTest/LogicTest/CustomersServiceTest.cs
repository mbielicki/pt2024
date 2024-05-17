using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using Bookshop.Logic.Customers;
using BookshopTest.Data.InMemoryMockStorage;
using BookshopTest.Data.SampleMockStorage;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class CustomersServiceTest
    {
        [TestMethod]
        public void testAddGet()
        {
            //IBookshopStorage storage = new SampleMockStorage();
            IBookshopStorage storage = new InMemoryMockStorage();
            CustomersService customers = new CustomersService(storage);

            ICustomer customer = DataGenerator.newCustomer();

            int id = customers.add(customer);
            Assert.AreEqual(customer.FirstName, customers.get(id).FirstName);

            ICustomer identicalCustomer = DataGenerator.copy(customer);
            Assert.ThrowsException<ItemAlreadyExists>(() => customers.add(identicalCustomer));

            ICustomer incorrect = DataGenerator.newCustomer();
            incorrect.LastName = "";

            Assert.ThrowsException<InvalidItemProperties>(() => customers.add(incorrect));
        }

        [TestMethod]
        public void testUpdateRemove()
        {
            //IBookshopStorage storage = new SampleMockStorage();
            IBookshopStorage storage = new InMemoryMockStorage();
            CustomersService customers = new CustomersService(storage);

            ICustomer customer = DataGenerator.newCustomer();
            int id = customers.add(customer);

            ICustomer newCustomer = DataGenerator.copy(customer);
            newCustomer.FirstName = "John";
            newCustomer.Id = id;

            customers.update(newCustomer);
            Assert.AreEqual(newCustomer.FirstName, customers.get(id).FirstName);

            customers.remove(id);
            Assert.ThrowsException<ItemIdNotFound>(() => customers.remove(id));
        }
    }
}
