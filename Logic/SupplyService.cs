using Data.API;
using Data.Model.Entities;
using Logic.Model;

namespace Logic
{
    public class SupplyService : IEventService<Model.Entities.ISupply>
    {
        IDataLayer _dataLayer;
        public SupplyService(IDataLayer dataLayer) { _dataLayer = dataLayer; }
        public Model.Entities.ISupply get(int id)
        {
            ISupply? result = _dataLayer.Supply.get(i => i.Id.Equals(id));
            if (result == null)
                throw new ItemIdNotFound();
            return result.ToLogic();
        }

        public List<int> getIds()
        {
            return _dataLayer.Supply.getAll((i) => true).ConvertAll(i => (int) i.Id);

        }
    }
}
