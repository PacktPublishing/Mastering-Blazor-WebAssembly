using Microsoft.Extensions.Primitives;

namespace BooksStore.Server.Models
{
    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

