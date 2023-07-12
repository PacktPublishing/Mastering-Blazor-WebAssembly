using BooksStore.Api.Models;

namespace BooksStore.Api.Interfaces
{
	public interface IAuthenticationService
	{

		Task<LoginResponse> LoginAsync(LoginRequest model);

	}
}
