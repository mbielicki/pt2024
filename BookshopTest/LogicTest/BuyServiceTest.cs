using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class BuyServiceTest
    {
        [TestMethod]
        public void testCheckPrice()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            CatalogueService catalogue = new CatalogueService(storage);

            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price1 = 10;
            Book book1 = new Book(null, name, author, description, price1);
            ID id1 = catalogue.add(book1);

            double price2 = 20;
            Book book2 = new Book(null, "Dziady part III", author, "", price2);    
            ID id2 = catalogue.add(book2);

            Counter<ID> books = new Counter<ID>();
            books.add(id1);
            books.add(id2);
            books.add(id2);
            double expectedPrice = price1 + price2 * 2;

            BuyService buyService = new BuyService(storage);
            double buyPrice = buyService.checkPrice(books);

            Assert.AreEqual(expectedPrice, buyPrice);
        }

    }
}
