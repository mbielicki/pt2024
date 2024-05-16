using Bookshop.Data.API;
using Bookshop.Data.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic
{
    public class SupplyRegisterService
    {
        IBookshopStorage _storage;
        public SupplyRegisterService(IBookshopStorage storage) { _storage = storage; }
        public ISupply get(int id)
        {
            ISupply? result = _storage.Supply.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _storage.Supply.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }
    }
}
