namespace Bookshop.Data.Model
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }

        public Book(int? Id = null, string? Name = null, string? Author = null, string? Description = null, double? Price = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Book) return false;
            Book other = obj as Book;
            return this.Id == other.Id
                && this.Name == other.Name
                && this.Author == other.Author
                && this.Description == other.Description
                && this.Price == other.Price;
        }
    }
}
