using Bookshop.Data.API;
using Bookshop.Data.Database.Model;
using Bookshop.Data.Model.Entities;
using Bookshop.Data.Model;
using Bookshop.Logic;

namespace Bookshop.Data.Database
{
    internal class SupplyAPI : IStorageAPI<ISupply>
    {
        public int add(ISupply modelItem)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                int newSupplyId;
                try
                {
                    newSupplyId = database.Supplies.Max(i => i.SupplyId) + 1;
                } catch (InvalidOperationException)
                {
                    newSupplyId = 0;
                }

                Supplier supplier = (from c in database.Suppliers
                                    where c.SupplierId == modelItem.Supplier.Id
                                    select c).Single();

                foreach (var bookNumber in modelItem.Books)
                {
                    int bookId = (int) bookNumber.Key.Id;
                    int numOfBooks = bookNumber.Value;

                    SupplyBookList bookList = new SupplyBookList()
                    {
                        Supply = newSupplyId,
                        Book = bookId,
                        Count = numOfBooks
                    };

                    database.SupplyBookLists.InsertOnSubmit(bookList);
                }

                Supply newItem = new Supply()
                {
                    SupplyId = newSupplyId,
                    Supplier = supplier.SupplierId,
                    Price = modelItem.Price,
                    DateTime = modelItem.DateTime
                };
            

                database.Supplies.InsertOnSubmit(newItem);
                database.SubmitChanges();

                modelItem.Id = newSupplyId;
                return (int) modelItem.Id;
            }
        }

        public ISupply? get(Predicate<ISupply> query)
        {
            using(BookshopDataContext database = new BookshopDataContext())
            {
                Func<Supply, bool> predicate = (item) =>
                {
                    return query(toISupply(item));
                };

                IEnumerable<Supply> result = database.Supplies.Where(predicate);
                Supply firstResult;
                try
                {
                    firstResult = result.First();
                }
                catch (InvalidOperationException e)
                {
                    return null;
                }
                return toISupply(firstResult);
            }
        }

        private ISupply toISupply(Supply item)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Counter<IBook> bookCounter = new Counter<IBook>();

                IEnumerable<SupplyBookList> dbBooks = from bl in database.SupplyBookLists
                                            where bl.Supply == item.SupplyId 
                                            select bl;
                foreach (var b in dbBooks)
                {
                    int bookId = b.Book;
                    int count = b.Count;

                    bookCounter.Set((from i in database.Books
                                      where i.BookId == bookId
                                      select i).Single().ToIBook(), count);
                    
                }

                ISupplier supplier = (from c in database.Suppliers
                                    where c.SupplierId == item.Supplier
                                    select c).Single().ToISupplier();

                return new SimpleSupply()
                {
                    Id = item.SupplyId,
                    Books = bookCounter,
                    Supplier = supplier,
                    Price = item.Price,
                    DateTime = item.DateTime
                };
            }
        }

        private List<ISupply> toISupply(IEnumerable<Supply> items)
        {

            List<ISupply> result = new List<ISupply>();
            foreach (var item in items)
            {
                result.Add(toISupply(item));
            }
            return result;
        }

        public List<ISupply> getAll(Predicate<ISupply> query)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                Func<Supply, bool> predicate = (item) =>
                {
                    return query(toISupply(item));
                };

                IEnumerable<Supply> result = database.Supplies.Where(predicate);
                return toISupply(result);
            }
        }

        public bool remove(int id)
        {
            using (BookshopDataContext database = new BookshopDataContext())
            {
                var bookListEntries = from entry in database.SupplyBookLists
                               where entry.Supply == id
                               select entry;

                foreach (var entry in bookListEntries)
                {
                    database.SupplyBookLists.DeleteOnSubmit(entry);
                }

                var result = from item in database.Supplies
                                    where item.SupplyId == id
                                    select item;
                try
                {
                    database.Supplies.DeleteOnSubmit(result.Single());
                    database.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void update(ISupply modelItem)
        {

            using (BookshopDataContext database = new BookshopDataContext())
            {
                var query = from i in database.Supplies
                             where i.SupplyId == modelItem.Id
                             select i;

                try
                {
                    Supply dbSupply = query.Single();

                    dbSupply.Supplier = (int)modelItem.Supplier.Id;
                    dbSupply.Price = modelItem.Price;
                    dbSupply.DateTime = modelItem.DateTime;

                    var bookList = from entry in database.SupplyBookLists
                                   where entry.Supply == modelItem.Id
                                   select entry;

                    database.SupplyBookLists.DeleteAllOnSubmit(bookList);


                    foreach (var bookNumber in modelItem.Books)
                    {
                        int bookId = (int)bookNumber.Key.Id;
                        int numOfBooks = bookNumber.Value;

                        SupplyBookList ibList = new SupplyBookList()
                        {
                            Supply = (int)modelItem.Id,
                            Book = bookId,
                            Count = numOfBooks
                        };

                        database.SupplyBookLists.InsertOnSubmit(ibList);
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
