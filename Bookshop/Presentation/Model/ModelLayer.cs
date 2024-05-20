using Bookshop.Data.Database.Model;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using System.Collections.ObjectModel;

namespace Bookshop.Presentation.Model
{
    public interface IModelLayer
    {
        void addBook(IBook book);
        IBook? getBook(int key);
        ObservableCollection<IBook> getBooksObservable();
        ObservableCollection<ICustomer> getCustomersObservable();
        ObservableCollection<IInventoryEntry> getInventoryObservable();
        ObservableCollection<IInvoice> getInvoicesObservable();
        ObservableCollection<ISupplier> getSuppliersObservable();
        ObservableCollection<ISupply> getSuppliesObservable();
        void updateBook(IBook book);
        void updateCustomer(ICustomer customer);
        void addCustomer(ICustomer customer);
        void updateSupplier(ISupplier supplier);
        void addSupplier(ISupplier supplier);
        void Buy(int customer, IEnumerable<IInventoryEntry> shoppingCart);
        double CheckPrice(ObservableCollection<IInventoryEntry> shoppingCart);
    }
    class ModelLayer : IModelLayer
    {
        private ILogicLayer _logic;

        public ModelLayer(ILogicLayer logicLayer)
        {
            _logic = logicLayer;
        }

        public ObservableCollection<ISupply> getSuppliesObservable()
        {
            ObservableCollection<ISupply> supplies = new ObservableCollection<ISupply>();

            IEnumerable<int> ids = _logic.SupplyService.getIds();
            foreach (int id in ids)
            {
                supplies.Add(_logic.SupplyService.get(id));
            }

            return supplies;
        }
        public ObservableCollection<IBook> getBooksObservable()
        {
            ObservableCollection<IBook> books = new ObservableCollection<IBook>();

            IEnumerable<int> ids = _logic.CatalogueService.getIds();
            foreach (int id in ids)
            {
                books.Add(_logic.CatalogueService.get(id));
            }

            return books;
        }
        public ObservableCollection<ICustomer> getCustomersObservable()
        {
            ObservableCollection<ICustomer> customers = new ObservableCollection<ICustomer>();

            IEnumerable<int> ids = _logic.CustomersService.getIds();
            foreach (int id in ids)
            {
                customers.Add(_logic.CustomersService.get(id));
            }

            return customers;
        }
        public ObservableCollection<IInvoice> getInvoicesObservable()
        {
            ObservableCollection<IInvoice> invoices = new ObservableCollection<IInvoice>();

            IEnumerable<int> ids = _logic.InvoicesService.getIds();
            foreach (int id in ids)
            {
                invoices.Add(_logic.InvoicesService.get(id));
            }

            return invoices;
        }
        public ObservableCollection<ISupplier> getSuppliersObservable()
        {
            ObservableCollection<ISupplier> suppliers = new ObservableCollection<ISupplier>();

            IEnumerable<int> ids = _logic.SuppliersService.getIds();
            foreach (int id in ids)
            {
                suppliers.Add(_logic.SuppliersService.get(id));
            }
            return suppliers;
        }

        public ObservableCollection<IInventoryEntry> getInventoryObservable()
        {
            ObservableCollection<IInventoryEntry> inventory = [.. _logic.InventoryService.getAll()];
            return inventory;
        }

        public IBook? getBook(int id)
        {
            return _logic.CatalogueService.get(id);
        }

        public void updateBook(IBook book)
        {
            _logic.CatalogueService.update(book);
        }

        public void addBook(IBook book)
        {
            _logic.CatalogueService.add(book);
        }
        public void updateCustomer(ICustomer customer)
        {
            _logic.CustomersService.update(customer);
        }
        public void addCustomer(ICustomer customer)
        {
            _logic.CustomersService.add(customer);
        }
        public void updateSupplier(ISupplier supplier)
        {
            _logic.SuppliersService.update(supplier);
        }
        public void addSupplier(ISupplier supplier)
        {
            _logic.SuppliersService.add(supplier);
        }

        public void Buy(int customer, IEnumerable<IInventoryEntry> shoppingCart)
        {
            Counter<int> books = new Counter<int>();
            foreach(var bookNumber in shoppingCart)
            {
                int book = (int)bookNumber.Book.Id;
                int count = bookNumber.Count;

                books.Set(book, count);
            }

            _logic.BuyService.buy(customer, books);
        }

        public double CheckPrice(ObservableCollection<IInventoryEntry> shoppingCart)
        {
            Counter<int> books = new Counter<int>();
            foreach (var bookNumber in shoppingCart)
            {
                int book = (int)bookNumber.Book.Id;
                int count = bookNumber.Count;

                books.Set(book, count);
            }

            return _logic.BuyService.checkPrice(books);
        }
    }
}
