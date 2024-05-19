using Bookshop.Data.API;
using Bookshop.Data.Database;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic.Customers;
using System.Collections.ObjectModel;

namespace Bookshop.Model
{
    public class CustomersLoader
    {
        public static ObservableCollection<ICustomer> loadCustomers()
        {
            ObservableCollection<ICustomer> customers = new ObservableCollection<ICustomer>();

            IBookshopStorage storage = new DatabaseBookshopStorage();
            CustomersService service = new CustomersService(storage);

            IEnumerable<int> ids = service.getIds();
            foreach (int id in ids)
            {
                customers.Add(service.get(id));
            }

            return customers;
        }
    }
}
