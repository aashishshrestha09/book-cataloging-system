namespace csharp.Models
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public double Price { get; set; }

        public Book() { }

        public Book(string title, string author, string genre, int publicationYear, double price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = publicationYear;
            Price = price;
        }
    }
}
