using Model.Model;
using Model.Model.Entities;
using static BookshopTest.DataGenerator;

namespace BookshopTest
{
    internal static class EventGenerator
    {
        public static IEnumerable<IInvoice> newInvoicesRandom()
        {
            return new List<IInvoice>() {
                new RandomInvoice(),
                new RandomInvoice(),
                new RandomInvoice()
            };
        }
        public static IEnumerable<IInvoice> newInvoicesHardCoded()
        {
            return new List<IInvoice>() {
                new InvoiceCustomizable(20, DateTime.Parse("20/03/2022 10:00:00")),
                new InvoiceCustomizable(30, DateTime.Parse("25/04/2023 16:00:00")),
                new InvoiceCustomizable(100, DateTime.Parse("10/05/2024 12:00:00"))
            };
        }

        internal static IEnumerable<ISupply> newSuppliesRandom()
        {
            return new List<ISupply>() {
                new RandomSupply(),
                new RandomSupply(),
                new RandomSupply()
            };
        }
        private class RandomSupply : ISupply
        {
            public int? Id { get; set; }
            public ISupplier Supplier { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public RandomSupply()
            {
                Random r = new Random();
                Books = newBooks();
                Supplier = newSupplier();
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
                Id = 0;
            }
        }


        private class RandomInvoice : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public RandomInvoice()
            {
                Random r = new Random();
                Books = newBooks();
                Customer = newCustomer();
                Price = r.NextDouble() * 100 + 10;
                DateTime = DateTime.Now;
            }
        }
        private class InvoiceCustomizable : IInvoice
        {
            public int? Id { get; set; }
            public ICustomer Customer { get; set; }
            public double Price { get; set; }
            public DateTime DateTime { get; set; }
            public Counter<IBook> Books { get; set; }
            public InvoiceCustomizable(double price, DateTime time)
            {
                Id = null;
                Books = newBooks();
                Customer = newCustomer();
                Price = price;
                DateTime = time;
            }
        }

    }
}
