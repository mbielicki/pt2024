using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    internal class InvoicesAPI : IInMemoryStorage<Invoice>
    {
        public InvoicesAPI(List<Invoice> document) : base(document)
        {
        }
        public override void update(Invoice newInvoice)
        {
            Invoice invoiceToUpdate = _document.Find(i => i.Id == newInvoice.Id);
            invoiceToUpdate.Books = newInvoice.Books;
            invoiceToUpdate.Customer = newInvoice.Customer;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.DateTime = newInvoice.DateTime;
        }

    }
}
