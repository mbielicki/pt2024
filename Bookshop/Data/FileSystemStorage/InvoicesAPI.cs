using Bookshop.Data.Model;

namespace Bookshop.Data.FileSystemStorage
{
    internal class InvoicesAPI : IFileSystemStorage<Invoice>
    {
        public InvoicesAPI(string document) : base(document)
        {
        }
        public override void update(Invoice newInvoice)
        {
            Invoice invoiceToUpdate = get(i => i.Id == newInvoice.Id);
            invoiceToUpdate.Books = newInvoice.Books;
            invoiceToUpdate.Customer = newInvoice.Customer;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.DateTime = newInvoice.DateTime;
        }

    }
}
