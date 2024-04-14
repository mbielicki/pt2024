namespace Bookshop.Data.Model
{
    public class Book : HasId
    {
        public ID? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        
        public Book(ID? Id, string? Title, string? Author, string? Description, double? Price)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.Description = Description;
            this.Price = Price;
        }
    }
}
