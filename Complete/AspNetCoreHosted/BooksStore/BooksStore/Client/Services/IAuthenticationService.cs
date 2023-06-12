using BooksStore.Shared;

namespace BooksStore.Client.Services;

public interface IAuthenticationService
{
	Task<LoginResponse> LoginUserAsync(LoginRequest requestModel);
	Task RegisterUserAsync(RegisterUserRequest requestModel);
}
