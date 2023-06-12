using BooksStore.Server.Exceptions;
using BooksStore.Server.Models;
using BooksStore.Shared;

namespace BooksStore.Server.Services
{
    public class BooksService
    {

        private readonly IWebHostEnvironment _env;


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

		public BooksService(IWebHostEnvironment env)
		{
			_env = env;
		}

		public Task<List<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_allBooks.Select(b => new Book()
            {
                Id = b.Id,  
                Category = b.Category,
                AuthorName = b.AuthorName,
                PublishingDate = b.PublishingDate,
                Title = b.Title,
                Price = b.Price,
            }).ToList());
        }

		public Task<Book?> GetByIdAsync(string id)
		{
			return Task.FromResult(_allBooks.FirstOrDefault(i => i.Id == id));
		}

		public Task AddBookAsync(SubmitBook book)
        {
            _allBooks.Add(new()
            {
                AuthorName = book.Author,
                Description = book.Description,
                PagesCount = book.PagesCount,
                Price = book.Price,
                Title = book.Title,
            });

            return Task.CompletedTask;
        }

        public async Task SetCoverAsync(string bookId, IFormFile file)
        {
            var book = _allBooks.FirstOrDefault(b => b.Id == bookId);
			if (book == null)
            {
				throw new DomainException("Book not found");
			}

			var fileName = $"{bookId}-{Guid.NewGuid()}.jpg";
			var filePath = Path.Combine(_env.ContentRootPath, "wwwroot", "images", fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
            {
				await file.CopyToAsync(stream);
			}
            book.CoverImageUrl = $"/images/{fileName}";
        }

        public Task AddReviewAsync(string bookId, AddBookReviewRequest review)
        {
			var book = _allBooks.FirstOrDefault(b => b.Id == bookId);
			if (book == null)
            {
				throw new DomainException("Book not found");
			}

			book.Reviews.Add(new()
            {
				Description = review.Description,
                Rating = review.Rating,
                Id = Guid.NewGuid().ToString(),
			});

			return Task.CompletedTask;
		}


    }
}
