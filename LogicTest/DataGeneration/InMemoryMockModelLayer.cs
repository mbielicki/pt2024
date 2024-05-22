using Data.Model.Entities;
using Presentation.Model;
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

        public void addBook(IBook book)
        {
            _books.Add(book);
        }

        public void addCustomer(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void addSupplier(ISupplier supplier)
        {
            _suppliers.Add(supplier);
        }

        public void Buy(int customer, IEnumerable<IInventoryEntry> shoppingCart)
        {
            foreach (var item in shoppingCart)
            {
                foreach (var i in _inventory)
                {
                    if (item.Book.Id == i.Book.Id)
                        i.Count -= item.Count;
                }
            }
        }

        public double CheckPrice(ObservableCollection<IInventoryEntry> shoppingCart)
        {
            double result = 0;
            foreach (var item in shoppingCart)
            {
                result += getBook((int)item.Book.Id).Price;
            }
            return result;
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

        public void Supply(int supplier, IEnumerable<IInventoryEntry> shoppingCart, double price)
        {
            foreach (var item in shoppingCart)
            {
                foreach (var i in _inventory)
                {
                    if (item.Book.Id == i.Book.Id)
                        i.Count += item.Count;
                }
            }
        }

        public void updateBook(IBook book)
        {
            _books[(int)book.Id] = book;
        }

        public void updateCustomer(ICustomer customer)
        {
            _customers[(int)customer.Id] = customer;
        }

        public void updateSupplier(ISupplier supplier)
        {
            _suppliers[(int)supplier.Id] = supplier;
        }
    }
}
