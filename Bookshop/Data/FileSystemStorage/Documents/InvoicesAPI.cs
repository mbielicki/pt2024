using Bookshop.Data.API;
using Bookshop.Data.Model;
using static Bookshop.Data.FileSystemStorage.Serialization;

namespace Bookshop.Data.FileSystemStorage
{
    internal class InvoicesAPI : IStorageAPI<IInvoice>
    {
        int nextId;
        List<Invoice> _document;
        readonly string filePath;
        CatalogueAPI catalogue;
        CustomersAPI customers;

        public InvoicesAPI(string filePath, CatalogueAPI catalogue, CustomersAPI customers)
        {
            this.filePath = filePath;
            this.catalogue = catalogue;
            this.customers = customers;
            _document = new List<Invoice>();
            try
            {
                _document = ReadInvoicesXml(filePath, catalogue, customers);
                nextId = getAll((i) => true).ConvertAll(i => i.Id.Value).Max() + 1;
            }
            catch (Exception)
            {
                _document.toXml(filePath);
                nextId = 0;
            }
        }

        public ID add(IInvoice item)
        {
            ID id = new ID(nextId++);
            item.Id = id;

            _document = ReadInvoicesXml(filePath, catalogue, customers);
            _document.Add(new Invoice(item.Id, item.Books, item.Customer, item.Price, item.DateTime));
            _document.toXml(filePath);

            return id;
        }

        public IInvoice? get(Predicate<IInvoice> query)
        {
            _document = ReadInvoicesXml(filePath, catalogue, customers);
            return _document.Find(query);
        }

        public List<IInvoice> getAll(Predicate<IInvoice> query)
        {
            _document = ReadInvoicesXml(filePath, catalogue, customers);

            return [.. _document.FindAll(query)];
        }

        public bool remove(ID id)
        {
            _document = ReadInvoicesXml(filePath, catalogue, customers);
            foreach (Invoice item in _document)
            {
                if (item.Id.Equals(id))
                {
                    _document.Remove(item);
                    _document.toXml(filePath);
                    return true;
                }
            }
            return false;
        }

        public void update(IInvoice newInvoice)
        {
            _document = ReadInvoicesXml(filePath, catalogue, customers);

            IInvoice invoiceToUpdate = get(i => i.Id.Equals(newInvoice.Id));
            invoiceToUpdate.Books = newInvoice.Books;
            invoiceToUpdate.Customer = newInvoice.Customer;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.DateTime = newInvoice.DateTime;

            _document.toXml(filePath);
        }

    }
}
