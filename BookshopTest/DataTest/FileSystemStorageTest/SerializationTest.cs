using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.Model;
using Bookshop.Logic.Catalogue;
using Bookshop.Logic;
using Bookshop.Data.API;

namespace BookshopTest.DataTest.FileSystemStorageTest
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void testWriteToXmlFile()
        {
            string file = "Generated Files\\BookshopFileSystemStorage\\temp.xml";
            List<Book> books = new List<Book>();
            Book a = DataGenerator.newBook();
            a.Id = new ID(100);
            books.Add(a);
            Book b = DataGenerator.newBook();
            b.Id = new ID(102);
            books.Add(b);

            Serialization.WriteToXmlFile(file, books);

            List<Book> read = Serialization.ReadFromXmlFile<List<Book>>(file);
            Assert.AreEqual(books[1].Title, read.Last().Title);
        }

        [TestMethod]
        public void testReadFromXmlFile() 
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();

            ID id1 = storage.Catalogue.add(DataGenerator.newBook());

            Book book = DataGenerator.newBook();
            ID id2 = storage.Catalogue.add(book);
            book.Id = id2;

            ID id3 = storage.Catalogue.add(DataGenerator.newBook());

            Assert.AreEqual(book.Title, storage.Catalogue.get(b => b.Id.Equals(id2)).Title);
        }
    }
}
