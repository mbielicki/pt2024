using BookshopTest.Data.SampleMockStorage;
using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;
using BookshopTest.Data.InMemoryMockStorage;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InvoicesServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            //IBookshopStorage storage = new SampleMockStorage();
            IBookshopStorage storage = new InMemoryMockStorage();
            InvoicesService invoices = new InvoicesService(storage);


            //IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesRandom(storage);
            IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesHardCoded(storage);

            IInvoice firstInvoice = invoicesList.First();
            firstInvoice.Id = storage.Invoices.add(firstInvoice);

            Assert.AreEqual(firstInvoice.Price, invoices.get((int) firstInvoice.Id).Price);
        }
    }
}
