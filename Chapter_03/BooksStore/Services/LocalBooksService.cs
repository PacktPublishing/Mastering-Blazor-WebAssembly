using BooksStore.Models;
namespace BooksStore.Services;
public class LocalBooksService : IBooksService
{
	static List<Book> _allBooks = new List<Book>
	{
		 new Book
		 {
			 AuthorName = "John Smith",
			 PublishingDate = new DateTime(2021, 01, 12),
			 Title = "Blazor WebAssembly Guide"
		 },
		 new Book
		 {
			 AuthorName = "John Smith",
			 PublishingDate = new DateTime(2022, 03, 13),
			 Title = "Mastering Blazor WebAssembly",
		 },
		 new Book
		 {
			 AuthorName = "John Smith",
			 PublishingDate = new DateTime(2022, 08, 01),
			 Title = "Learning Blazor from A to Z"
		 }
	};

	public Task<List<Book>> GetAllBooksAsync()
	{
		return Task.FromResult(_allBooks);
	}
}
