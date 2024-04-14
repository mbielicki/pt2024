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
            _document = Serialization.ReadFromXmlFile<List<Supplier>>(filePath);

            Supplier supplierToUpdate = get(s => s.Id.Equals(newSupplier.Id));
            supplierToUpdate.FirstName = newSupplier.FirstName;
            supplierToUpdate.LastName = newSupplier.LastName;
            supplierToUpdate.Address = newSupplier.Address;
            supplierToUpdate.ContactInfo = newSupplier.ContactInfo;

            Serialization.WriteToXmlFile(filePath, _document);
        }

    }
}
