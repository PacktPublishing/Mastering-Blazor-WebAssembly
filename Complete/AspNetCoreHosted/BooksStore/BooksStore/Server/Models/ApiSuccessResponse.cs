namespace BooksStore.Server.Models
{
    public class ApiSuccessResponse<T>
    {
        public T? Value { get; set; }

        public string? Message { get; set; }
    }
}

