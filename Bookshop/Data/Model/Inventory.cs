namespace Bookshop.Data.Model
{
    public class Inventory
    {
        private Dictionary<Book, int> inventory;

        public Inventory()
        {
            inventory = new Dictionary<Book, int>();
        }

        public void Add(Book book)
        {
            if (inventory.ContainsKey(book))
                inventory[book]++;
            else
                inventory.Add(book, 1);
        }
        public void Remove(Book book)
        {
            if (inventory.ContainsKey(book))
            {
                int newCount = inventory[book] - 1;
                if (newCount > 0)
                    inventory[book] = newCount;
                else inventory.Remove(book);

            }

            else throw new NoSuchBookInInventory();
        }

        public int Count(Book book)
        {
            if (!inventory.ContainsKey(book)) return 0;
            return inventory[book];
        }
    }

    public class NoSuchBookInInventory : Exception
    {

    }
}
