﻿namespace Bookshop.Data.Model
{
    public class SupplyRegisterEntry : Event
    {
        public ID? Id { get; set; }
        public Supplier Supplier { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
        public Counter<ID> Books { get; set; }
        public SupplyRegisterEntry(ID? id, Counter<ID> books, Supplier supplier, double price, DateTime dateTime)
        {
            Id = id;
            Books = books;
            Supplier = supplier;
            Price = price;
            DateTime = dateTime;
        }
        public SupplyRegisterEntry() { }
    }
}