using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic.Customers;

namespace Bookshop.Logic
{
    public class BuyService : IBuyService
    {
        IDataLayer _dataLayer;
        public BuyService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public int buy(int customerId, Counter<int> books)
        {
            CustomersService customers = new CustomersService(_dataLayer);
            CatalogueService catalogue = new CatalogueService(_dataLayer);
            ICustomer customer = customers.get(customerId);

            foreach (var idToNumber in books)
            {
                int id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;
                int numberInStock = _dataLayer.Inventory.count(id);

                if (numberToBuy > numberInStock)
                    throw new NotEnoughItemsInInventory(id);
            }

            foreach (var idToNumber in books)
            {
                int id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;

                _dataLayer.Inventory.remove(id, numberToBuy);
            }

            Counter<IBook> bookRefs = new Counter<IBook>();
            foreach (var idToNumber in books)
            {
                int id = idToNumber.Key;
                int numberToBuy = idToNumber.Value;

                bookRefs.Set(catalogue.get(id), numberToBuy);
            }

            double price = checkPrice(books);
            SimpleInvoice invoice = new SimpleInvoice(null, bookRefs, customer, price, DateTime.Now);
            return _dataLayer.Invoices.add(invoice);
        }
        public double checkPrice(Counter<int> books)
        {
            double totalPrice = 0;
            CatalogueService catalogue = new CatalogueService(_dataLayer);

            foreach (var idToNumber in books)
            {
                int id = idToNumber.Key;
                int number = idToNumber.Value;
                totalPrice += (double)catalogue.get(id).Price * number;
            }

            return totalPrice;
        }
    }
}
