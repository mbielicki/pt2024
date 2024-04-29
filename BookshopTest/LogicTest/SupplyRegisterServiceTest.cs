using Bookshop.Model.Data.FileSystemStorage;
using Bookshop.Model.Data.API;
using Bookshop.Model.Data.Model;
using Bookshop.Model.Data.Model.Entities;
using Bookshop.Model.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class SupplyRegisterServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            SupplyRegisterService register = new SupplyRegisterService(storage);

            ISupplier supplier = DataGenerator.newSupplier();
            supplier.Id = storage.Suppliers.add(supplier);
            IBook book = DataGenerator.newBook();
            ID bookId = storage.Catalogue.add(book);

            Counter<IBook> books = new Counter<IBook>();
            double price = 50;
            DateTime now = DateTime.Now;

            books.Add(book);
            SupplyRegisterEntry entry = new SupplyRegisterEntry(null, books, supplier, price, now);
            ID id = storage.SupplyRegister.add(entry);


            Assert.AreEqual(price, register.get(id).Price);
        }
    }
}
