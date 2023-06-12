namespace BooksStore.Server.Models
{
    public class Book
    {

        public Book()
        {
            Reviews = new();
        }

        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AuthorName { get; set; }
        public decimal Price { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishingDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Category { get; set; }
        public List<Review> Reviews { get; set; }
    }

    public class Review
    {

        public Review()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
    }
}

