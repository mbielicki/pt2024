using Bookshop.Data.API;
using Bookshop.Data.Model;

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
            throw new NotImplementedException();
        }
    }
}
