using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class SupplyRegisterAPI : IInMemoryStorage<SupplyRegisterEntry>
    {
        public SupplyRegisterAPI(List<SupplyRegisterEntry> document) : base(document)
        {
        }
        public override void update(SupplyRegisterEntry newEntry)
        {
            SupplyRegisterEntry entryToUpdate = _document.Find(i => i.Id == newEntry.Id);
            entryToUpdate.Books = newEntry.Books;
            entryToUpdate.Supplier = newEntry.Supplier;
            entryToUpdate.Price = newEntry.Price;
            entryToUpdate.DateTime = newEntry.DateTime;
        }

    }
}
