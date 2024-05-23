using Logic;
using Logic.Model.Entities;

namespace ModelTest.MockLogicLayer
{
    public class MockLogicLayer : ILogicLayer
    {
        public IService<IBook> CatalogueService { get; }

        public IService<ICustomer> CustomersService { get; }

        public IService<ISupplier> SuppliersService { get; }

        public IEventService<IInvoice> InvoicesService { get; }

        public IEventService<ISupply> SupplyService { get; }

        public IInventoryService InventoryService { get; }

        public IBuyService BuyService { get; }

        public MockLogicLayer()
        {
            CatalogueService = new MockCatalogueService();
            CustomersService = new MockCustomersService();
            SuppliersService = new MockSuppliersService();
            InvoicesService = new MockInvoicesService();
            SupplyService = new MockSupplyService();
            InventoryService = new MockInventoryService();
            BuyService = new MockBuyService();
        }
    }
}
