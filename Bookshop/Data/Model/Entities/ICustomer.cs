﻿using System;

namespace Bookshop.Data.Model
{
    public interface ICustomer : IPerson
    {
        public ID? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
    }

    public class Customer : ICustomer
    {
        public ID? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string ContactInfo { get; set; }

        public Customer(ID? id, string firstName, string lastName, string address, string contactInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ContactInfo = contactInfo;
        }
        public Customer() { }
    }
}