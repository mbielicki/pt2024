using Bookshop.Data.Model.Entities;
using Bookshop.Presentation.Model;
using System.Collections.ObjectModel;
using BookshopTest.DataGeneration.MockDataLayerInMemory;

namespace BookshopTest.DataGeneration
{
    public class InMemoryMockModelLayer : IModelLayer
    {
        ObservableCollection<IBook> _books;
        ObservableCollection<ICustomer> _customers;
        ObservableCollection<ISupplier> _suppliers;
        ObservableCollection<IInventoryEntry> _inventory;
        ObservableCollection<IInvoice> _invoices;
        ObservableCollection<ISupply> _supplies;
        public InMemoryMockModelLayer()
        {
            _books =
            [
                DataGenerator.newBook(),
                DataGenerator.newBook(),
                DataGenerator.newBook(),
                DataGenerator.newBook(),
                DataGenerator.newBook(),
                DataGenerator.newBook(),
                DataGenerator.newBook(),
            ];

            int i = 0;
            foreach (var book in _books)
            {
                book.Id = i++;
            }

            _customers =
            [
                DataGenerator.newCustomer(),
                DataGenerator.newCustomer(),
                DataGenerator.newCustomer(),
                DataGenerator.newCustomer(),
                DataGenerator.newCustomer()
            ];
            i = 0;
            foreach (var customer in _customers)
            {
                customer.Id = i++;
            }


            _suppliers =
            [
                DataGenerator.newSupplier(),
                DataGenerator.newSupplier(),
                DataGenerator.newSupplier(),
                DataGenerator.newSupplier(),
                DataGenerator.newSupplier()
            ];
            i = 0;
            foreach (var supplier in _suppliers)
            {
                supplier.Id = i++;
            }



            _inventory =
            [
                new SimpleInventoryEntry()
                {
                    Book = DataGenerator.newBook(),
                    Count = 2
                },
                new SimpleInventoryEntry()
                {
                    Book = DataGenerator.newBook(),
                    Count = 2
                },
            ];


            var newInvoices = EventGenerator.newInvoicesRandom(new InMemoryMockDataLayer());
            _invoices = [.. newInvoices];

            var newSupplies = EventGenerator.newSuppliesRandom(new InMemoryMockDataLayer());
            _supplies = [.. newSupplies];

        }
        public IBook? getBook(int key)
        {
            try
            {
                return _books[key];
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public ObservableCollection<IBook> getBooksObservable()
        {
            return _books;
        }

        public ObservableCollection<ICustomer> getCustomersObservable()
        {
            return _customers;
        }

        public ObservableCollection<IInventoryEntry> getInventoryObservable()
        {
            return _inventory;
        }

        public ObservableCollection<IInvoice> getInvoicesObservable()
        {
            return _invoices;
        }

        public ObservableCollection<ISupplier> getSuppliersObservable()
        {
            return _suppliers;
        }

        public ObservableCollection<ISupply> getSuppliesObservable()
        {
            return _supplies;
        }
    }
}
