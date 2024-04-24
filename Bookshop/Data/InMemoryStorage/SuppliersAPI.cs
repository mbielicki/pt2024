using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class SuppliersAPI : IInMemoryStorage<ISupplier>
    {
        public SuppliersAPI(List<ISupplier> document) : base(document)
        {
        }
        public override void update(ISupplier newSupplier)
        {
            ISupplier supplierToUpdate = _document.Find(s => s.Id.Equals(newSupplier.Id));
            supplierToUpdate.FirstName = newSupplier.FirstName;
            supplierToUpdate.LastName = newSupplier.LastName;
            supplierToUpdate.Address = newSupplier.Address;
            supplierToUpdate.ContactInfo = newSupplier.ContactInfo;
        }

    }
}
