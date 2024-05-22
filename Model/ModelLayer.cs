using Data.Model;
using Data.Model.Entities;
using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
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
        void Supply(int supplier, IEnumerable<IInventoryEntry> shoppingCart, double price);
    }
    public class ModelLayer : IModelLayer
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
                supplies.Add(_logic.SupplyService.get(id).ToData());
            }

            return supplies;
        }
        public ObservableCollection<IBook> getBooksObservable()
        {
            ObservableCollection<IBook> books = new ObservableCollection<IBook>();

            IEnumerable<int> ids = _logic.CatalogueService.getIds();
            foreach (int id in ids)
            {
                books.Add(_logic.CatalogueService.get(id).ToData());
            }

            return books;
        }
        public ObservableCollection<ICustomer> getCustomersObservable()
        {
            ObservableCollection<ICustomer> customers = new ObservableCollection<ICustomer>();

            IEnumerable<int> ids = _logic.CustomersService.getIds();
            foreach (int id in ids)
            {
                customers.Add(_logic.CustomersService.get(id).ToData());
            }

            return customers;
        }
        public ObservableCollection<IInvoice> getInvoicesObservable()
        {
            ObservableCollection<IInvoice> invoices = new ObservableCollection<IInvoice>();

            IEnumerable<int> ids = _logic.InvoicesService.getIds();
            foreach (int id in ids)
            {
                invoices.Add(_logic.InvoicesService.get(id).ToData());
            }

            return invoices;
        }
        public ObservableCollection<ISupplier> getSuppliersObservable()
        {
            ObservableCollection<ISupplier> suppliers = new ObservableCollection<ISupplier>();

            IEnumerable<int> ids = _logic.SuppliersService.getIds();
            foreach (int id in ids)
            {
                suppliers.Add(_logic.SuppliersService.get(id).ToData());
            }
            return suppliers;
        }

        public ObservableCollection<IInventoryEntry> getInventoryObservable()
        {
            ObservableCollection<IInventoryEntry> inventory = [.. _logic.InventoryService.getAll().ToData()];
            return inventory;
        }

        public IBook? getBook(int id)
        {
            return _logic.CatalogueService.get(id).ToData();
        }

        public void updateBook(IBook book)
        {
            _logic.CatalogueService.update(book.ToLogic());
        }

        public void addBook(IBook book)
        {
            _logic.CatalogueService.add(book.ToLogic());
        }
        public void updateCustomer(ICustomer customer)
        {
            _logic.CustomersService.update(customer.ToLogic());
        }
        public void addCustomer(ICustomer customer)
        {
            _logic.CustomersService.add(customer.ToLogic());
        }
        public void updateSupplier(ISupplier supplier)
        {
            _logic.SuppliersService.update(supplier.ToLogic());
        }
        public void addSupplier(ISupplier supplier)
        {
            _logic.SuppliersService.add(supplier.ToLogic());
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

            _logic.BuyService.buy(customer, books.ToLogic());
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

            return _logic.BuyService.checkPrice(books.ToLogic());
        }

        public void Supply(int supplier, IEnumerable<IInventoryEntry> shoppingCart, double price)
        {
            Counter<int> books = new Counter<int>();
            foreach (var bookNumber in shoppingCart)
            {
                int book = (int)bookNumber.Book.Id;
                int count = bookNumber.Count;

                books.Set(book, count);
            }

            _logic.InventoryService.supply(books.ToLogic(), supplier, price);
        }
    }
}
