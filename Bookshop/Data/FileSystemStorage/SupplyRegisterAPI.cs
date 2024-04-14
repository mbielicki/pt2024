using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class SupplyRegisterAPI : IFileSystemStorage<SupplyRegisterEntry>
    {
        public SupplyRegisterAPI(string document) : base(document)
        {
        }
        public override void update(SupplyRegisterEntry newEntry)
        {
            SupplyRegisterEntry entryToUpdate = get(i => i.Id.Equals(newEntry.Id));
            entryToUpdate.Books = newEntry.Books;
            entryToUpdate.Supplier = newEntry.Supplier;
            entryToUpdate.Price = newEntry.Price;
            entryToUpdate.DateTime = newEntry.DateTime;
        }

    }
}
