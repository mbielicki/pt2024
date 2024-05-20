using Bookshop.Data.API;
using Bookshop.Data.Database.Model;

namespace Bookshop.Data.Database
{
    internal class InventoryAPI : IInventoryAPI
    {
        private string _connectionString;

        public InventoryAPI(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void addOne(int item)
        {
            add(item, 1);
        }

        public void add(int item, int numberToSupply)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                var inventoryQuery = from i in database.Inventories
                                     where i.Book == item
                                     select i;
                Inventory inventory;

                try
                {
                    inventory = inventoryQuery.Single();
                    inventory.Count += numberToSupply;
                }
                catch (InvalidOperationException)
                {
                    Book book = (from b in database.Books
                                 where b.BookId == item
                                 select b).Single();

                    inventory = new Inventory()
                    {
                        Book = item,
                        Count = numberToSupply
                    };

                    database.Inventories.InsertOnSubmit(inventory);
                }

                database.SubmitChanges();
            }
        }

        public int count(int item)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                var inventoryQuery = from i in database.Inventories
                                     where i.Book == item
                                     select i;

                try
                {
                    Inventory inventory = inventoryQuery.Single();
                    return inventory.Count;
                }
                catch (InvalidOperationException)
                {
                    return 0;
                }
            }
        }

        public bool remove(int item, int numberToBuy)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                var inventoryQuery = from i in database.Inventories
                                     where i.Book == item
                                     select i;
                try
                {
                    Inventory inventory = inventoryQuery.Single();
                    int newCount = inventory.Count - numberToBuy;
                    if (newCount < 0) return false;

                    inventory.Count = newCount;
                    database.SubmitChanges();
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public bool removeOne(int id)
        {
            return remove(id, 1);
        }

        public IEnumerable<int> getIds()
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {

                var inventoryQuery = from i in database.Inventories
                                     select i.Book;
                return inventoryQuery.ToList();
            }
        }
    }
}
