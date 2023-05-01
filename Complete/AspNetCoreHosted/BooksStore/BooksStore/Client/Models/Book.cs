using System.Text.Json.Serialization;

namespace BooksStore.Client.Models;

public class Book
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("authorName")]
    public string? AuthorName { get; set; }
    [JsonPropertyName("publishingDate")]
    public DateTime PublishingDate { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("coverImageUrl")]
	public string? CoverImageUrl { get; set; }
	[JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("pagesCount")]
    public int PagesCount { get; set; }
}
