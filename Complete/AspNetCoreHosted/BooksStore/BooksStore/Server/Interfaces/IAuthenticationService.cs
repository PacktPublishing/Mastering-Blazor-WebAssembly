using BooksStore.Server.Models;

namespace BooksStore.Server.Interfaces
{
	public interface IAuthenticationService
	{

		Task<LoginResponse> LoginAsync(LoginRequest model);

	}
}
