using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Logic
{
    public class SupplyService : IEventService<ISupply>
    {
        IDataLayer _dataLayer;
        public SupplyService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public ISupply get(int id)
        {
            ISupply? result = _dataLayer.Supply.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result;
        }

        public List<int> getIds()
        {
            return _dataLayer.Supply.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }
    }
}
