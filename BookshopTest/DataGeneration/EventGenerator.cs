using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using static BookshopTest.DataGenerator;

namespace BookshopTest
{
    internal static class EventGenerator
    {
        public static IEnumerable<IInvoice> newInvoicesRandom(IBookshopStorage storage)
        {
            return new List<IInvoice>() {
                new RandomInvoice(storage),
                new RandomInvoice(storage),
                new RandomInvoice(storage)
            };
        }
        public static IEnumerable<IInvoice> newInvoicesHardCoded(IBookshopStorage storage)
        {
            return new List<IInvoice>() {
                new InvoiceCustomizable(storage, 20, DateTime.Parse("20/03/2022 10:00:00")),
                new InvoiceCustomizable(storage, 30, DateTime.Parse("25/04/2023 16:00:00")),
                new InvoiceCustomizable(storage, 100, DateTime.Parse("10/05/2024 12:00:00"))
            };
        }
        private class RandomInvoice : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public RandomInvoice(IBookshopStorage storage)
            {
                Random r = new Random();
                Books = newBooks(storage);
                Customer = newCustomer(storage);
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
                Id = storage.Invoices.add(this);
            }
        }
        private class InvoiceCustomizable : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public InvoiceCustomizable(IBookshopStorage storage, double price, DateTime time)
            {
                Id = null;
                Books = newBooks(storage);
                Customer = newCustomer(storage);
                Price = price;
                DateTime = time;
            }
        }

    }
}
