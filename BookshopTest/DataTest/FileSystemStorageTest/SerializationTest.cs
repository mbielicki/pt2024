using static Bookshop.Data.FileSystemStorage.Serialization;
using Bookshop.Data.FileSystemStorage;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic;
using Bookshop.Data.API;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.FileSystemStorageTest
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void testWriteToXmlFile()
        {
            string file = "Generated Files\\BookshopFileSystemStorage\\temp.xml";

            FileSystemBookshopStorage storage = new FileSystemBookshopStorage();

            Counter<IBook> books = new Counter<IBook>();
            Book a = DataGenerator.newBook();
            a.Id = storage.Catalogue.add(a);
            books.Add(a);
            
            Book b = DataGenerator.newBook();
            b.Id = storage.Catalogue.add(b);
            books.Add(b);
            books.Add(a);

            Customer customer = DataGenerator.newCustomer();
            customer.Id = storage.Customers.add(customer);


            List<Invoice> invoices = new List<Invoice>();
            invoices.Add(new Invoice(new ID(200), books, customer, 33.3, DateTime.Now));
            invoices.Add(new Invoice(new ID(201), books, customer, 33.3, DateTime.Now));

            invoices.toXml(file);

            List<Invoice> read = ReadInvoicesXml(file, storage.Catalogue, storage.Customers);
            Assert.AreEqual(invoices[1].Price, read.Last().Price);
        }

        [TestMethod]
        public void testReadFromXmlFile() 
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();

            ID id1 = storage.Catalogue.add(DataGenerator.newBook());

            IBook book = DataGenerator.newBook();
            ID id2 = storage.Catalogue.add(book);
            book.Id = id2;

            ID id3 = storage.Catalogue.add(DataGenerator.newBook());

            Assert.AreEqual(book.Title, storage.Catalogue.get(b => b.Id.Equals(id2)).Title);
        }
    }
}
