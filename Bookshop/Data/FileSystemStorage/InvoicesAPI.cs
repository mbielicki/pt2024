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
            _document = Serialization.ReadFromXmlFile<List<Invoice>>(filePath);

            Invoice invoiceToUpdate = get(i => i.Id.Equals(newInvoice.Id));
            invoiceToUpdate.Books = newInvoice.Books;
            invoiceToUpdate.Customer = newInvoice.Customer;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.DateTime = newInvoice.DateTime;

            Serialization.WriteToXmlFile(filePath, _document);
        }

    }
}
