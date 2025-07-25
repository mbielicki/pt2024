﻿using Data.API;
using Logic.Model.Entities;
using Logic;
using BookshopTest.DataGeneration.MockDataLayerInMemory;
using Logic.Model;

namespace BookshopTest.LogicTest
{
    [TestClass]
    public class InvoicesServiceTest
    {
        [TestMethod]
        public void testGet()
        {
            //IDataLayer dataLayer = new SampleMockDataLayer();
            IDataLayer dataLayer = new InMemoryMockDataLayer();
            ILogicLayer logic = new LogicLayer(dataLayer);
            IEventService<IInvoice> invoices = logic.InvoicesService;


            //IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesRandom(dataLayer);
            IEnumerable<IInvoice> invoicesList = EventGenerator.newInvoicesHardCoded(dataLayer);

            IInvoice firstInvoice = invoicesList.First();
            firstInvoice.Id = dataLayer.Invoices.add(firstInvoice.ToData());

            Assert.AreEqual(firstInvoice.Price, invoices.get((int) firstInvoice.Id).Price);
        }
    }
}
