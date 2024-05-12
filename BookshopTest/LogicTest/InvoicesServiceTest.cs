using Bookshop.Data.FileSystemStorage;
using Bookshop.Data.API;
using Bookshop.Data.Model.Entities;
using Bookshop.Logic;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InvoicesServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            IBookshopStorage storage = new FileSystemBookshopStorage();
            InvoicesService invoices = new InvoicesService(storage);


            //IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesRandom(storage);
            IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesHardCoded(storage);

            IInvoice firstInvoice = invoicesList.First();
            firstInvoice.Id = storage.Invoices.add(firstInvoice);

            Assert.AreEqual(firstInvoice.Price, invoices.get(firstInvoice.Id).Price);
        }
    }
}
