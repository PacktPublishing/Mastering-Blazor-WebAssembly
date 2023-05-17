namespace BooksStore.Api.Models
{
    public class ApiErrorResponse
    {
        public string? Message { get; set; }

        public IEnumerable<string>? Errors { get; set; }
    }
}

