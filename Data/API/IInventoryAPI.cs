namespace Data.API
{
    public interface IInventoryAPI
    {
        void addOne(int item);
        void add(int item, int numberToSupply);
        bool removeOne(int item);
        bool remove(int id, int numberToBuy);
        int count(int item);
        IEnumerable<int> getIds();
    }
}
