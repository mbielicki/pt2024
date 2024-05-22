using Data.API;
using Logic.Model;
using Logic.Model.Entities;
using Logic.Catalogue;
using Logic.Suppliers;

namespace Logic
{
    public class InventoryService : IInventoryService
    {
        IDataLayer _dataLayer;
        public InventoryService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public int count(int bookId)
        {
            return _dataLayer.Inventory.count(bookId);
        }
        public void supply(int bookId, int supplierId, double price)
        {
            Counter<int> books = new Counter<int>();
            books.Add(bookId);
            supply(books, supplierId, price);
        }
        public void supply(Counter<int> bookIds, int supplierId, double price)
        {
            SuppliersService suppliers = new SuppliersService(_dataLayer);
            ISupplier supplier = suppliers.get(supplierId);

            CatalogueService catalogue = new CatalogueService(_dataLayer);

            if (bookIds.Count() == 0)
                throw new EmptyBookCounterException();

            foreach (var bookToNumber in bookIds)
            {
                int book = bookToNumber.Key;
                int number = bookToNumber.Value;

                if (number <= 0)
                {
                    throw new BookWithCountZeroInCounterException(book);
                }
            }

            Counter<IBook> books = new Counter<IBook>();

            foreach (var bookToNumber in bookIds)
            {
                int book = bookToNumber.Key;
                int number = bookToNumber.Value;


                books.Set(catalogue.get(book), number);

                _dataLayer.Inventory.add(book, number);
            }


            SimpleSupply registerEntry = new SimpleSupply(
                null, books, supplier, price, DateTime.Now);

            _dataLayer.Supply.add(registerEntry.ToData());
        }
        public IEnumerable<IInventoryEntry> getAll()
        {
            CatalogueService catalogue = new CatalogueService(_dataLayer);

            List<IInventoryEntry> wholeInventory = new List<IInventoryEntry> ();

            foreach(int bookId in _dataLayer.Inventory.getIds())
            {
                wholeInventory.Add(new SimpleInventoryEntry()
                {
                    Book = catalogue.get(bookId), 
                    Count = _dataLayer.Inventory.count(bookId)
                });
            }
            return wholeInventory;
        }

    }
}
