using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace Bookshop.Data.InMemoryStorage
{
    public class InMemoryBookshopStorage : IBookshopStorage
    {
        Counter<ID> inventory = new Counter<ID>();
        List<Book> catalogue = new List<Book>();
        List<Customer> customers = new List<Customer>();
        List<Invoice> invoices = new List<Invoice>();


        public IStorage<Book> Catalogue { get; }

        public IStorage<Customer> Customers { get; }

        public InMemoryBookshopStorage()
        {
            Catalogue = new CatalogueAPI(catalogue);
            Customers = new CustomersAPI(customers);
        }
    }
}

