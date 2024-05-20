using Bookshop.Data.Model.Entities;

namespace BookshopTest.DataGeneration.MockDataLayerInMemory
{
    internal class SupplyAPI : IInMemoryStorage<ISupply>
    {
        public SupplyAPI(List<ISupply> document) : base(document)
        {
        }
        public override void update(ISupply newEntry)
        {
            ISupply entryToUpdate = _document.Find(i => i.Id.Equals(newEntry.Id));
            entryToUpdate.Books = newEntry.Books;
            entryToUpdate.Supplier = newEntry.Supplier;
            entryToUpdate.Price = newEntry.Price;
            entryToUpdate.DateTime = newEntry.DateTime;
        }

    }
}
