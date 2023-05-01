using System.Text.Json.Serialization;

namespace BooksStore.Client.Models;

public class ApiErrorResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("errors")]
    public string[]? Errors { get; set; }
}
