using BooksStore.Server.Models;
using BooksStore.Server.Services;
using BooksStore.Shared;
using BooksStore.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BooksStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            // Validate the model 
            var result = await _booksService.GetAllBooksAsync();
            return Ok(result.ToArray());
        }

		[ProducesResponseType(200, Type = typeof(Book))]
		[ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			// Validate the model 
			var result = await _booksService.GetByIdAsync(id);
            if (result == null)
                return NotFound(); 
			return Ok(result);
		}

		[ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] SubmitBook model)
        {
            // Validate the model 
            await _booksService.AddBookAsync(model);
            return Ok();
        }

		[ProducesResponseType(200)]
		[ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
		[HttpPost("{bookId}/cover")]
		public async Task<IActionResult> UploadCover(string bookId, [FromForm] IFormFile file)
		{
			// Validate the model 
			await _booksService.SetCoverAsync(bookId, file);
			return Ok();
		}


		[ProducesResponseType(200)]
		[ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
		[HttpPost()]
		[HttpPost("review/{bookId}")]
        public async Task<IActionResult> AddReview(string bookId, [FromBody] AddBookReviewRequest model)
        {
			// Validate the model 
			await _booksService.AddReviewAsync(bookId, model);
			return Ok();
		}

        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<Book>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPut()]
        public Task<IActionResult> Update([FromBody] AddBookRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<Book>()));
        }

        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<bool>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute]string id)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<Book>()));
        }

    }


}