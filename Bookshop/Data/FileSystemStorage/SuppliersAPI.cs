using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class SuppliersAPI : IFileSystemStorage<Supplier>
    {
        public SuppliersAPI(string document) : base(document)
        {
        }
        public override void update(Supplier newSupplier)
        {
            Supplier supplierToUpdate = new Supplier(null, null, null, null, null, null); //_document.Find(s => s.Id == newSupplier.Id);
            supplierToUpdate.FirstName = newSupplier.FirstName;
            supplierToUpdate.LastName = newSupplier.LastName;
            supplierToUpdate.Address = newSupplier.Address;
            supplierToUpdate.ContactInfo = newSupplier.ContactInfo;
        }

    }
}
