using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Data.Model;
using System.Security.Cryptography;
using Bookshop.Logic;

namespace Bookshop.Data.Database
{
    internal class InvoicesAPI : IStorageAPI<IInvoice>
    {
        public int add(IInvoice modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                int newInvoiceId;
                try
                {
                    newInvoiceId = database.Invoices.Max(i => i.InvoiceId) + 1;
                } catch (InvalidOperationException)
                {
                    newInvoiceId = 0;
                }
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
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
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
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                Counter<IBook> bookCounter = new Counter<IBook>();

                IEnumerable<InvoiceBookList> dbBooks = from bl in database.InvoiceBookLists
                                            where bl.Invoice == item.InvoiceId 
                                            select bl;
                foreach (var b in dbBooks)
                {
                    int bookId = b.Book;
                    int count = b.Count;

                    bookCounter.Set((from i in database.Books
                                      where i.BookId == bookId
                                      select i).Single().ToIBook(), count);
                    
                }

                ICustomer customer = (from c in database.Customers
                                    where c.CustomerId == item.Customer
                                    select c).Single().ToICustomer();

                return new SimpleInvoice()
                {
                    Id = item.InvoiceId,
                    Books = bookCounter,
                    Customer = customer,
                    Price = item.Price,
                    DateTime = item.DateTime
                };
            }
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
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
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
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                var bookListEntries = from entry in database.InvoiceBookLists
                               where entry.Invoice == id
                               select entry;

                foreach (var entry in bookListEntries)
                {
                    database.InvoiceBookLists.DeleteOnSubmit(entry);
                }

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
            using (BookshopDataContext database = new BookshopDataContext(ConnectionString.Get()))
            {
                var query = from i in database.Invoices
                             where i.InvoiceId == modelItem.Id
                             select i;

                try
                {
                    Invoice dbInvoice = query.Single();

                    dbInvoice.Customer = (int)modelItem.Customer.Id;
                    dbInvoice.Price = modelItem.Price;
                    dbInvoice.DateTime = modelItem.DateTime;

                    var bookList = from entry in database.InvoiceBookLists
                                   where entry.Invoice == modelItem.Id
                                   select entry;

                    database.InvoiceBookLists.DeleteAllOnSubmit(bookList);


                    foreach (var bookNumber in modelItem.Books)
                    {
                        int bookId = (int)bookNumber.Key.Id;
                        int numOfBooks = bookNumber.Value;

                        InvoiceBookList ibList = new InvoiceBookList()
                        {
                            Invoice = (int)modelItem.Id,
                            Book = bookId,
                            Count = numOfBooks
                        };

                        database.InvoiceBookLists.InsertOnSubmit(ibList);
                    }

                    database.SubmitChanges();
                } catch (Exception ex)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
