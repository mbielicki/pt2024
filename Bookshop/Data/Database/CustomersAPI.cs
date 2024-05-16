using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    internal class CustomersAPI : IStorageAPI<ICustomer>
    {

        public int add(ICustomer item)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                int newId = database.Customers.Max(i => i.CustomerId) + 1;
                Customer newItem = new Customer()
                {
                    CustomerId = newId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Address = item.Address,
                    ContactInfo = item.ContactInfo,
                };
            

                database.Customers.InsertOnSubmit(newItem);
                database.SubmitChanges();

                item.Id = newId;
                return (int) item.Id;
            }
        }

        public ICustomer? get(Predicate<ICustomer> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Customer, bool> predicate = (item) =>
                {
                    return query(toICustomer(item));
                };

                IEnumerable<Customer> result = database.Customers.Where(predicate);
                Customer firstResult;
                try
                {
                    firstResult = result.First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
                return toICustomer(firstResult);
            }
        }

        private ICustomer toICustomer(Customer item)
        {
            return new SimpleCustomer()
            {
                Id = item.CustomerId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                ContactInfo = item.ContactInfo
            };
        }

        private List<ICustomer> toICustomer(IEnumerable<Customer> items)
        {
            List<ICustomer> result = new List<ICustomer>();
            foreach (var item in items)
            {
                result.Add(toICustomer(item));
            }
            return result;
        }

        public List<ICustomer> getAll(Predicate<ICustomer> query)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Func<Customer, bool> predicate = (item) =>
                {
                    return query(toICustomer(item));
                };

                IEnumerable<Customer> result = database.Customers.Where(predicate);
                return toICustomer(result);
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {

                var result = from item in database.Customers
                                    where item.CustomerId == id
                                    select item;

                try
                {
                    database.Customers.DeleteOnSubmit(result.Single());
                    database.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void update(ICustomer modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                var query = from i in database.Customers
                             where i.CustomerId == modelItem.Id
                             select i;

                try
                {
                    Customer dbCustomer = query.Single();

                    dbCustomer.FirstName = modelItem.FirstName;
                    dbCustomer.LastName = modelItem.LastName;
                    dbCustomer.Address = modelItem.Address;
                    dbCustomer.ContactInfo = modelItem.ContactInfo;

                    database.SubmitChanges();
                } catch (Exception ex)
                {

                }
            }
        }
    }
}
