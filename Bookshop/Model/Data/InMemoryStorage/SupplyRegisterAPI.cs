using Bookshop.Model.Data.Model.Entities;

namespace Bookshop.Model.Data.InMemoryStorage
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
