using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using System.Collections.ObjectModel;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.DataGeneration
{
    public class SampleMockModelLayer : IModelLayer
    {
        public IBook? getBook(int key)
        {
            IBook book = DataGenerator.newBook();
            book.Id = key;
            return book;
        }

        public ObservableCollection<IBook> getBooksObservable()
        {
            ObservableCollection<IBook> books = new();
            books.Add(getBook(0));
            books.Add(getBook(1));
            return books;
        }

        public ObservableCollection<ICustomer> getCustomersObservable()
        {
            ObservableCollection<ICustomer> customers = new();

            ICustomer customer1 = DataGenerator.newCustomer();
            customer1.Id = 0;
            customers.Add(customer1);

            ICustomer customer2 = DataGenerator.newCustomer();
            customer2.Id = 1;
            customers.Add(customer2);

            return customers;
        }

        public ObservableCollection<IInventoryEntry> getInventoryObservable()
        {
            ObservableCollection<IInventoryEntry> inventory = new();

            inventory.Add(new SimpleInventoryEntry()
            {
                Book = DataGenerator.newBook(),
                Count = 2
            });
            inventory.Add(new SimpleInventoryEntry()
            {
                Book = DataGenerator.newBook(),
                Count = 2
            });

            return inventory;
        }

        public ObservableCollection<IInvoice> getInvoicesObservable()
        {
            var newInvoices = EventGenerator.newInvoicesRandom(new InMemoryMockDataLayer());
            return [..newInvoices];
        }

        public ObservableCollection<ISupplier> getSuppliersObservable()
        {
            ObservableCollection<ISupplier> suppliers = new();

            ISupplier supplier1 = DataGenerator.newSupplier();
            supplier1.Id = 0;
            suppliers.Add(supplier1);

            ISupplier supplier2 = DataGenerator.newSupplier();
            supplier2.Id = 1;
            suppliers.Add(supplier2);

            return suppliers;
        }

        public ObservableCollection<ISupply> getSuppliesObservable()
        {
            var newSupplies = EventGenerator.newSuppliesRandom(new InMemoryMockDataLayer());
            return [.. newSupplies];
        }
    }
}
