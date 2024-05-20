using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    internal class SuppliersAPI : IStorageAPI<ISupplier>
    {

        public int add(ISupplier modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                int newId = database.Suppliers.Max(i => i.SupplierId) + 1;
                Supplier newItem = new Supplier()
                {
                    SupplierId = newId,
                    FirstName = modelItem.FirstName,
                    LastName = modelItem.LastName,
                    CompanyName = modelItem.CompanyName,
                    Address = modelItem.Address,
                    ContactInfo = modelItem.ContactInfo,
                };
            

                database.Suppliers.InsertOnSubmit(newItem);
                database.SubmitChanges();

                modelItem.Id = newId;
                return (int) modelItem.Id;
            }
        }

        public ISupplier? get(Predicate<ISupplier> query)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                Func<Supplier, bool> predicate = (item) =>
                {
                    return query(toISupplier(item));
                };

                IEnumerable<Supplier> result = database.Suppliers.Where(predicate);
                Supplier firstResult;
                try
                {
                    firstResult = result.First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
                return toISupplier(firstResult);
            }
        }

        private ISupplier toISupplier(Supplier item)
        {
            return new SimpleSupplier()
            {
                Id = item.SupplierId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                CompanyName = item.CompanyName,
                Address = item.Address,
                ContactInfo = item.ContactInfo
            };
        }

        private List<ISupplier> toISupplier(IEnumerable<Supplier> items)
        {
            List<ISupplier> result = new List<ISupplier>();
            foreach (var item in items)
            {
                result.Add(toISupplier(item));
            }
            return result;
        }

        public List<ISupplier> getAll(Predicate<ISupplier> query)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                Func<Supplier, bool> predicate = (item) =>
                {
                    return query(toISupplier(item));
                };

                IEnumerable<Supplier> result = database.Suppliers.Where(predicate);
                return toISupplier(result);
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                var result = from item in database.Suppliers
                                    where item.SupplierId == id
                                    select item;

                try
                {
                    database.Suppliers.DeleteOnSubmit(result.Single());
                    database.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void update(ISupplier modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                var query = from i in database.Suppliers
                             where i.SupplierId == modelItem.Id
                             select i;

                Supplier dbSupplier = query.Single();

                dbSupplier.FirstName = modelItem.FirstName;
                dbSupplier.LastName = modelItem.LastName;
                dbSupplier.CompanyName = modelItem.CompanyName;
                dbSupplier.Address = modelItem.Address;
                dbSupplier.ContactInfo = modelItem.ContactInfo;

                database.SubmitChanges();
            }
        }
    }
}
