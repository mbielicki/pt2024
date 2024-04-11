namespace Bookshop.Data.Model
{
    public class Book
    {
        public int? Id { get; set; }
        public string Name { get; private set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Book(int Id, string Name, string Author, string Description, double Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }
        public Book(string Name, string Author, string Description, double Price)
        {
            Id = null;
            this.Name = Name;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Book))
                return false;
            return Id == ((Book)obj).Id;
        }
    }
}
