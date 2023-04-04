using BooksStore.Api.Models;
using BooksStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers
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

        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            // Validate the model 
            var result = await _booksService.GetAllBooksAsync();
            return Ok(result.ToArray());
        }

        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost()]
        public Task<IActionResult> Add([FromBody] AddBookRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<Book>()));
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