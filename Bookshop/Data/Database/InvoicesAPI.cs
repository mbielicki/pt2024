using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;

namespace Bookshop.Data.Database
{
    internal class InvoicesAPI : IStorageAPI<IInvoice>
    {
        public int add(IInvoice modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                int newInvoiceId = database.Invoices.Max(i => i.InvoiceId) + 1;
                Customer customer = (from c in database.Customers
                                    where c.CustomerId == modelItem.Customer.Id
                                    select c).Single();

                foreach (var bookNumber in modelItem.Books)
                {
                    int bookId = (int) bookNumber.Key.Id;
                    int numOfBooks = bookNumber.Value;

                    InvoiceBookList ibList = new InvoiceBookList()
                    {
                        Invoice = newInvoiceId,
                        Book = bookId,
                        Count = numOfBooks
                    };

                    database.InvoiceBookLists.InsertOnSubmit(ibList);
                }

                Invoice newItem = new Invoice()
                {
                    InvoiceId = newInvoiceId,
                    Customer = customer.CustomerId,
                    Price = modelItem.Price,
                    DateTime = modelItem.DateTime
                };
            

                database.Invoices.InsertOnSubmit(newItem);
                database.SubmitChanges();

                modelItem.Id = newInvoiceId;
                return (int) modelItem.Id;
            }
        }

        public IInvoice? get(Predicate<IInvoice> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Invoice, bool> predicate = (item) =>
                {
                    return query(toIInvoice(item));
                };

                IEnumerable<Invoice> result = database.Invoices.Where(predicate);
                Invoice firstResult;
                try
                {
                    firstResult = result.First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
                return toIInvoice(firstResult);
            }
        }

        private IInvoice toIInvoice(Invoice item)
        {
            return new SimpleInvoice()
            {
                Id = item.InvoiceId,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                ContactInfo = item.ContactInfo
            };
        }

        private List<IInvoice> toIInvoice(IEnumerable<Invoice> items)
        {
            List<IInvoice> result = new List<IInvoice>();
            foreach (var item in items)
            {
                result.Add(toIInvoice(item));
            }
            return result;
        }

        public List<IInvoice> getAll(Predicate<IInvoice> query)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Func<Invoice, bool> predicate = (item) =>
                {
                    return query(toIInvoice(item));
                };

                IEnumerable<Invoice> result = database.Invoices.Where(predicate);
                return toIInvoice(result);
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {

                var result = from item in database.Invoices
                                    where item.InvoiceId == id
                                    select item;

                try
                {
                    database.Invoices.DeleteOnSubmit(result.Single());
                    database.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void update(IInvoice modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                var query = from i in database.Invoices
                             where i.InvoiceId == modelItem.Id
                             select i;

                try
                {
                    Invoice dbInvoice = query.Single();

                    dbInvoice.FirstName = modelItem.FirstName;
                    dbInvoice.LastName = modelItem.LastName;
                    dbInvoice.Address = modelItem.Address;
                    dbInvoice.ContactInfo = modelItem.ContactInfo;

                    database.SubmitChanges();
                } catch (Exception ex)
                {

                }
            }
        }
    }
}
