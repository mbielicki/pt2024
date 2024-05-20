using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using static BookshopTest.DataGenerator;

namespace BookshopTest
{
    internal static class EventGenerator
    {
        public static IEnumerable<IInvoice> newInvoicesRandom(IDataLayer dataLayer)
        {
            return new List<IInvoice>() {
                new RandomInvoice(dataLayer),
                new RandomInvoice(dataLayer),
                new RandomInvoice(dataLayer)
            };
        }
        public static IEnumerable<IInvoice> newInvoicesHardCoded(IDataLayer dataLayer)
        {
            return new List<IInvoice>() {
                new InvoiceCustomizable(dataLayer, 20, DateTime.Parse("20/03/2022 10:00:00")),
                new InvoiceCustomizable(dataLayer, 30, DateTime.Parse("25/04/2023 16:00:00")),
                new InvoiceCustomizable(dataLayer, 100, DateTime.Parse("10/05/2024 12:00:00"))
            };
        }
        private class RandomInvoice : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public RandomInvoice(IDataLayer dataLayer)
            {
                Random r = new Random();
                Books = newBooks(dataLayer);
                Customer = newCustomer(dataLayer);
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
                Id = dataLayer.Invoices.add(this);
            }
        }
        private class InvoiceCustomizable : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public InvoiceCustomizable(IDataLayer dataLayer, double price, DateTime time)
            {
                Id = null;
                Books = newBooks(dataLayer);
                Customer = newCustomer(dataLayer);
                Price = price;
                DateTime = time;
            }
        }

    }
}
