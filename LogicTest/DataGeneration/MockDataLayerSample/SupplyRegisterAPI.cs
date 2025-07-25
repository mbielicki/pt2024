﻿using Data.Model.Entities;

namespace BookshopTest.DataGeneration.MockDataLayerSample
{
    internal class SupplyAPI : ISampleStorage<ISupply>
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
