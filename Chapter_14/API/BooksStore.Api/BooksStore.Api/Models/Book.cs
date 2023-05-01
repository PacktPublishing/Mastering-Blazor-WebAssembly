namespace BooksStore.Api.Models
{
    public class Book
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AuthorName { get; set; }
        public decimal Price { get; set; }
        public int PagesCount { get; set; }
        public DateTime PublishingDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Category { get; set; }
    }
}

