using BooksStore.Server.Models;
using BooksStore.Shared.Models;

namespace BooksStore.Server.Interfaces
{
	public interface IAuthenticationService
	{

		Task<LoginResponse> LoginAsync(LoginRequest model);

		Task RegisterAsync(RegisterUserRequest model);

	}
}
