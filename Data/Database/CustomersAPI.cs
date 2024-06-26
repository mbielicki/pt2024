﻿using Data.API;
using Data.Database.Model;
using Data.Model;
using Data.Model.Entities;

namespace Data.Database
{
    internal class CustomersAPI : IStorageAPI<ICustomer>
    {
        private string _connectionString;

        public CustomersAPI(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int add(ICustomer item)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
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
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                Func<Customer, bool> predicate = (item) =>
                {
                    return query(item.ToICustomer());
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
                return firstResult.ToICustomer();
            }
        }


        public List<ICustomer> getAll(Predicate<ICustomer> query)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                Func<Customer, bool> predicate = (item) =>
                {
                    return query(item.ToICustomer());
                };

                IEnumerable<Customer> result = database.Customers.Where(predicate);
                return result.ToICustomer();
                
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
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
            using (BookshopDataContext database = new BookshopDataContext(_connectionString))
            {
                var query = from i in database.Customers
                             where i.CustomerId == modelItem.Id
                             select i;

                Customer dbCustomer = query.Single();

                dbCustomer.FirstName = modelItem.FirstName;
                dbCustomer.LastName = modelItem.LastName;
                dbCustomer.Address = modelItem.Address;
                dbCustomer.ContactInfo = modelItem.ContactInfo;

                database.SubmitChanges();
            }
        }
    }
}
