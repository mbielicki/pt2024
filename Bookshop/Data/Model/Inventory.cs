namespace Bookshop.Data.Model
{
    public class Inventory
    {
        private Dictionary<int, int> inventory;

        public Inventory()
        {
            inventory = new Dictionary<int, int>();
        }

        public void Add(int bookId)
        {
            if (inventory.ContainsKey(bookId))
                inventory[bookId]++;
            else
                inventory.Add(bookId, 1);
        }
        public void Remove(int bookId)
        {
            int newCount = inventory[bookId] - 1;
            if (newCount > 0)
                inventory[bookId] = newCount;
            else inventory.Remove(bookId);
        }

        public int Count(int bookId)
        {
            if (!inventory.ContainsKey(bookId)) return 0;
            return inventory[bookId];
        }
    }

    public class NoSuchBookInInventory : Exception
    {

    }
}
