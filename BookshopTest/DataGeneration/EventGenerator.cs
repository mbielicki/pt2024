using Bookshop.Data.API;
using Bookshop.Data.Model;
using static BookshopTest.DataGenerator;

namespace BookshopTest
{
    internal static class EventGenerator
    {
        public static IEnumerable<IInvoice> newInvoicesInStorage(IBookshopStorage storage)
        {
            return new List<IInvoice>() {
                new StorageInvoice(storage),
                new StorageInvoice(storage),
                new StorageInvoice(storage)
            };
        }
        public static IEnumerable<IInvoice> newInvoiceNoId()
        {
            return new List<IInvoice>() {
                new InvoiceNoId(),
                new InvoiceNoId(),
                new InvoiceNoId()
            };
        }
        private class StorageInvoice : IInvoice
        {

            public ID? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public StorageInvoice(IBookshopStorage storage)
            {
                Random r = new Random();
                Books = newBooks(storage);
                Customer = newCustomer(storage);
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
                Id = storage.Invoices.add(this);
            }
        }
        private class InvoiceNoId : IInvoice
        {
            public ID? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public InvoiceNoId()
            {
                Random r = new Random();
                Id = null;
                Books = newBooks();
                Customer = newCustomer();
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
            }
        }

    }
}
