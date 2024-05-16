using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;

namespace Bookshop.Logic
{
    public class BuyService
    {
        IBookshopStorage _storage;
        public BuyService(IBookshopStorage storage) { _storage = storage; }
        public ID buy(ID customerId, Counter<ID> books)
        {
            CustomersService customers = new CustomersService(_storage);
            CatalogueService catalogue = new CatalogueService(_storage);
            ICustomer customer = customers.get(customerId);

            foreach (var idToNumber in books)
            {
                ID id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;
                int numberInStock = _storage.Inventory.count(id);

                if (numberToBuy > numberInStock)
                    throw new NotEnoughItemsInInventory();
            }

            foreach (var idToNumber in books)
            {
                ID id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;

                _storage.Inventory.remove(id, numberToBuy);
            }

            Counter<IBook> bookRefs = new Counter<IBook>();
            foreach (var idToNumber in books)
            {
                ID id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;

                bookRefs.Set(catalogue.get(id), numberToBuy);
            }

            double price = checkPrice(books);
            SimpleInvoice invoice = new SimpleInvoice(null, bookRefs, customer, price, DateTime.Now);
            return _storage.Invoices.add(invoice);
        }
        public double checkPrice(Counter<ID> books)
        {
            double totalPrice = 0;
            CatalogueService catalogue = new CatalogueService(_storage);

            foreach (var idToNumber in books)
            {
                ID id = idToNumber.Key;
                int number = idToNumber.Value;
                totalPrice += (double)catalogue.get(id).Price * number;
            }

            return totalPrice;
        }
    }
}
