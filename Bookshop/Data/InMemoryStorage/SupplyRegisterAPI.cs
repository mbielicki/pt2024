using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class SupplyRegisterAPI : IInMemoryStorage<ISupplyRegisterEntry>
    {
        public SupplyRegisterAPI(List<ISupplyRegisterEntry> document) : base(document)
        {
        }
        public override void update(ISupplyRegisterEntry newEntry)
        {
            ISupplyRegisterEntry entryToUpdate = _document.Find(i => i.Id.Equals(newEntry.Id));
            entryToUpdate.Books = newEntry.Books;
            entryToUpdate.Supplier = newEntry.Supplier;
            entryToUpdate.Price = newEntry.Price;
            entryToUpdate.DateTime = newEntry.DateTime;
        }

    }
}
