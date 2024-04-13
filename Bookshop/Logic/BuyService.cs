using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;

namespace Bookshop.Logic
{
    public class BuyService
    {
        IBookshopStorage _storage;
        public BuyService(IBookshopStorage storage) { _storage = storage; }
        public void buy(ID customer, List<ID> books)
        {
            throw new NotImplementedException();
        }
        public double checkPrice(List<ID> books)
        {
            double totalPrice = 0;
            CatalogueService catalogue = new CatalogueService(_storage);

            foreach (var id in books)
            {
                totalPrice += (double) catalogue.get(id).Price;
            }

            return totalPrice;
        }
    }
}
