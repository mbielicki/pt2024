﻿using Data.Model.Entities;

namespace BookshopTest.DataGeneration.MockDataLayerSample
{
    internal class InvoicesAPI : ISampleStorage<IInvoice>
    {
        public InvoicesAPI(List<IInvoice> document) : base(document)
        {
        }
        public override void update(IInvoice newInvoice)
        {
            IInvoice invoiceToUpdate = _document.Find(i => i.Id.Equals(newInvoice.Id));
            invoiceToUpdate.Books = newInvoice.Books;
            invoiceToUpdate.Customer = newInvoice.Customer;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.DateTime = newInvoice.DateTime;
        }

    }
}
