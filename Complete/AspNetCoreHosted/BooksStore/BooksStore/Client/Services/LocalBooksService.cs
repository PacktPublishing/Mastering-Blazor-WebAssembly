using BooksStore.Client.Models;

namespace BooksStore.Client.Services
{
    public class LocalBooksService : IBooksService
    {

        static List<Book> _allBooks = new List<Book>
        {
                 new Book
                 {
                     Id = "60ce7ea9-ebb7-4bc1-894b-df6ec5347a0a",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2021, 01, 12),
                     Title = "Blazor WebAssembly Guide",
                     Price = 45,
                     PagesCount = 300,
                 },
                 new Book
                 {
                     Id = "12fa4fa1-4022-46d7-97ff-9ff2c73d3bde",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2022, 03, 13),
                     Title = "Mastering Blazor WebAssembly",
                     Price = 35,
                     PagesCount = 200,
                 },
                 new Book
                 {
                     Id = "e6c0d89c-3767-4aea-a61d-2e1260c2004a",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2022, 08, 01),
                     Title = "Learning Blazor from A to Z",
                     Price = 40,
                     PagesCount = 250,
                 }
        };

		public Task AddBookAsync(SubmitBook book)
		{
			throw new NotImplementedException();
		}

		public Task<List<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_allBooks);
        }

        public Task<Book?> GetBookByIdAsync(string? id)
        {
            var book = _allBooks.SingleOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }
    }
}
