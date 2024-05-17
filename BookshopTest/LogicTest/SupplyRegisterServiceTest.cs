using BookshopTest.Data.Mock;
using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SupplyRegisterServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new InMemoryMockStorage();
            SupplyRegisterService register = new SupplyRegisterService(storage);

            ISupplier supplier = DataGenerator.newSupplier();
            supplier.Id = storage.Suppliers.add(supplier);
            IBook book = DataGenerator.newBook();
            int bookId = storage.Catalogue.add(book);

            Counter<IBook> books = new Counter<IBook>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(book);
            SimpleSupply entry = new SimpleSupply(null, books, supplier, price, now);
            int id = storage.Supply.add(entry);


            Assert.AreEqual(price, register.get(id).Price);
        }
    }
}
