using System.Xml.Serialization;
using Bookshop.Data.Model;

namespace Bookshop.Data.Model.Entities
{
    public interface IBook : HasId
    {
        string Title { get; set; }
        string Author { get; set; }
        string Description { get; set; }
        double Price { get; set; }
    }

    public class Book : IBook
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Book(ID Id, string Title, string Author, string Description, double Price)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }

        public Book() { }
    }
}
