using BooksStore.Models;

namespace BooksStore.Services;

public interface IBooksService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(string? id);
    Task AddBookAsync(SubmitBook book);
}
