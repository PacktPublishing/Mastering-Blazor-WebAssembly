using BooksStore.Models;

namespace BooksStore.Services;

public interface IBooksService
{
	Task<List<Book>> GetAllBooksAsync();
}
