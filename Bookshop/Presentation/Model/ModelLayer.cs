using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using Bookshop.Logic.Customers;
using Bookshop.Logic.Suppliers;
using System.Collections.ObjectModel;

namespace Bookshop.Model
{
    public interface IModelLayer
    {
        ObservableCollection<IBook> getBooksObservable();
        ObservableCollection<ICustomer> getCustomersObservable();
        ObservableCollection<IInvoice> getInvoicesObservable();
        ObservableCollection<ISupplier> getSuppliersObservable();
        ObservableCollection<ISupply> getSuppliesObservable();
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

            IDataLayer storage = new DatabaseBookshopStorage();
            CustomersService service = new CustomersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                customers.Add(service.get(id));
            }

            return customers;
        }
        public ObservableCollection<IInvoice> getInvoicesObservable()
        {
            ObservableCollection<IInvoice> invoices = new ObservableCollection<IInvoice>();

            IDataLayer storage = new DatabaseBookshopStorage();
            InvoicesService service = new InvoicesService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                invoices.Add(service.get(id));
            }

            return invoices;
        }
        public ObservableCollection<ISupplier> getSuppliersObservable()
        {
            ObservableCollection<ISupplier> suppliers = new ObservableCollection<ISupplier>();

            IDataLayer storage = new DatabaseBookshopStorage();
            SuppliersService service = new SuppliersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                suppliers.Add(service.get(id));
            }
            return suppliers;
        }
    }
}
