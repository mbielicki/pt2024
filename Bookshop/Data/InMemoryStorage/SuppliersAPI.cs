using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class SuppliersAPI : IInMemoryStorage<Supplier>
    {
        public SuppliersAPI(List<Supplier> document) : base(document)
        {
        }
        public override void update(Supplier newSupplier)
        {
            Supplier supplierToUpdate = _document.Find(s => s.Id == newSupplier.Id);
            supplierToUpdate.FirstName = newSupplier.FirstName;
            supplierToUpdate.LastName = newSupplier.LastName;
            supplierToUpdate.Address = newSupplier.Address;
            supplierToUpdate.ContactInfo = newSupplier.ContactInfo;
        }

    }
}
