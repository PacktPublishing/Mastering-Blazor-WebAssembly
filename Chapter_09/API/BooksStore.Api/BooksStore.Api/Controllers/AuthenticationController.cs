using BooksStore.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<LoginResponse>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("login")]
        public Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new LoginResponse()));
        }

        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<bool>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("register")]
        public Task<IActionResult> Register([FromBody] RegisterUserRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<bool>()));
        }

    }


}