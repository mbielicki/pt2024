using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.Model;

namespace BookshopTest.DataTest.FileSystemStorageTest
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void testWriteToXmlFile()
        {
            string file = "C:\\Users\\micha\\OneDrive\\Dokumenty\\sql\\c-sharp\\pt2024\\BookshopTest\\DataTest\\FileSystemStorageTest\\Generated Files\\temp.xml";
            Counter<ID> counter = new Counter<ID>();
            counter.Add(new ID(101));
            counter.Add(new ID(102));
            counter.Add(new ID(102));
            counter.Add(new ID(103));
            counter.Add(new ID(103));
            counter.Add(new ID(103));

            Serialization.WriteToXmlFile(file, counter);

            Counter<ID> read = Serialization.ReadFromXmlFile<Counter<ID>>(file);
            Assert.AreEqual(3, read.Last().Value);
        }
    }
}
