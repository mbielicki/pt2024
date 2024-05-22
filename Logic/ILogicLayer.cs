using Logic.Model.Entities;

namespace Logic
{
    public interface ILogicLayer
    {
        IService<IBook> CatalogueService { get; }
        IService<ICustomer> CustomersService { get; }
        IService<ISupplier> SuppliersService { get; }
        IEventService<IInvoice> InvoicesService { get; }
        IEventService<ISupply> SupplyService { get; }
        IInventoryService InventoryService { get; }
        IBuyService BuyService { get; }

    }
}
