using BooksStore.Client.Models;

namespace BooksStore.Client.Services;

public interface IBooksService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(string? id);
    Task AddBookAsync(SubmitBook book);
    Task AddReviewAsync(string bookId, AddBookReviewRequest review);
    Task UploadBookCoverAsync(string bookId, Stream stream, string fileName);
}
