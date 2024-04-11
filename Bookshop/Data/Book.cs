using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Data
{
    public class Book
    {
        public int Id {  get; private set; }
        public string Name { get; private set; }

        public string Author { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public Book(int Id, string Name, string Author, string Description, double Price) {
            this.Id = Id;
            this.Name = Name;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }
    }
}
