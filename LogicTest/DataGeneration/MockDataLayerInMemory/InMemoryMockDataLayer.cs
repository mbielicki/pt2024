﻿using Data.API;
using Data.Model;
using Data.Model.Entities;

namespace BookshopTest.DataGeneration.MockDataLayerInMemory
{
    public class InMemoryMockDataLayer : IDataLayer
    {
        Counter<int> inventory = new Counter<int>();
        List<IBook> catalogue = new List<IBook>();
        List<ICustomer> customers = new List<ICustomer>();
        List<ISupplier> suppliers = new List<ISupplier>();
        List<IInvoice> invoices = new List<IInvoice>();
        List<ISupply> supplyRegister = new List<ISupply>();

        public IInventoryAPI Inventory { get; }
        public IStorageAPI<IBook> Catalogue { get; }
        public IStorageAPI<ICustomer> Customers { get; }
        public IStorageAPI<ISupplier> Suppliers { get; }
        public IStorageAPI<IInvoice> Invoices { get; }
        public IStorageAPI<ISupply> Supply { get; }


        public InMemoryMockDataLayer()
        {
            Catalogue = new CatalogueAPI(catalogue);
            Customers = new CustomersAPI(customers);
            Suppliers = new SuppliersAPI(suppliers);
            Invoices = new InvoicesAPI(invoices);
            Supply = new SupplyAPI(supplyRegister);
            Inventory = new InventoryAPI(inventory);
        }
    }
}

