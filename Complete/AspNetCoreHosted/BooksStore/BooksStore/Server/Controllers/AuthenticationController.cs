using BooksStore.Server.Interfaces;
using BooksStore.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

		public AuthenticationController(IAuthenticationService authService)
		{
			_authService = authService;
		}

		[ProducesResponseType(200, Type = typeof(LoginResponse))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _authService.LoginAsync(model); 
            return Ok(result);
        }

        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<bool>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("register", Name = "Register")]
        public Task<IActionResult> Register([FromBody] RegisterUserRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<bool>()));
        }

    }


}