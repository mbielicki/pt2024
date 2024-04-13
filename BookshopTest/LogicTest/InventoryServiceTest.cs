using Bookshop.Data.API;
using Bookshop.Data.InMemoryStorage;
using Bookshop.Data.Model;
using Bookshop.Logic;
using Bookshop.Logic.Catalogue;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InventoryServiceTest
    {
        [TestMethod]
        public void testSupplyNewBook()
        {
            IBookshopStorage storage = new InMemoryBookshopStorage();
            InventoryService inventory = new InventoryService(storage);


            string name = "Pan Tadeusz";
            string author = "Adam Mickiewicz";
            string description = "The Last Foray in Lithuania";
            double price = 10;
            Book book = new Book(null, name, author, description, price);

            ID id = inventory.supply(book);

            Assert.AreEqual(1, inventory.count(id));

            inventory.supply(book);
            Assert.AreEqual(2, inventory.count(id));

            ID wrongId = new ID(id.Value + 1);
            Book wrongBook = new Book(wrongId, name, author, description, price);

            Assert.ThrowsException<IdenticalItemWithDifferentIdExists>(() =>
            {
                inventory.supply(wrongBook);
            });  

        }

    }
}
