using System.Text.Json.Serialization;

namespace BooksStore.Api.Models
{
    public class AddBookRequest
    {
		[JsonPropertyName("title")]
        public string? Title { get; set; }
		[JsonPropertyName("description")]
		public string? Description { get; set; }
		[JsonPropertyName("author")]
		public string? AuthorName { get; set; }
		[JsonPropertyName("price")]
		public decimal Price { get; set; }
		[JsonPropertyName("pagesCount")]
		public int PagesCount { get; set; }
		[JsonPropertyName("publishingDate")]
		public DateTime PublishingDate { get; set; }
		
	}
}

