using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;
using Bookshop.Logic.Suppliers;

namespace Bookshop.Logic
{
    public class LogicLayer : ILogicLayer
    {
        public LogicLayer(IDataLayer dataLayer)
        {
            CatalogueService = new CatalogueService(dataLayer);
            CustomersService = new CustomersService(dataLayer);
            SuppliersService = new SuppliersService(dataLayer); 
            InvoicesService = new InvoicesService(dataLayer);
            SupplyService = new SupplyService(dataLayer);
            InventoryService = new InventoryService(dataLayer);
            BuyService = new BuyService(dataLayer);
        }
        public IService<IBook> CatalogueService { get; }

        public IService<ICustomer> CustomersService { get; }

        public IService<ISupplier> SuppliersService { get; }

        public IEventService<IInvoice> InvoicesService { get; }

        public IEventService<ISupply> SupplyService { get; }

        public IInventoryService InventoryService { get; }

        public IBuyService BuyService { get; }
    }
}
