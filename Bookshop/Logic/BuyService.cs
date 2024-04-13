using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;

namespace Bookshop.Logic
{
    public class BuyService
    {
        IBookshopStorage _storage;
        public BuyService(IBookshopStorage storage) { _storage = storage; }
        public void buy(ID customer, Counter<ID> books)
        {
            //CustomersService customers = new CustomersService(_storage);
            //customers.get(customer);

            //foreach (var book in books)
            //{
            //    _storage.Inventory.count(book);

            //}

            //double price = checkPrice(books);

            throw new NotImplementedException();


        }
        public double checkPrice(Counter<ID> books)
        {
            double totalPrice = 0;
            CatalogueService catalogue = new CatalogueService(_storage);

            foreach (var idToNumber in books)
            {
                ID id = idToNumber.Key;
                int number = idToNumber.Value;
                totalPrice += (double) catalogue.get(id).Price * number;
            }

            return totalPrice;
        }
    }
}
