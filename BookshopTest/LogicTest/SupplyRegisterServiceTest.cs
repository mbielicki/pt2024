using Bookshop.Data.API;
using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;

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
