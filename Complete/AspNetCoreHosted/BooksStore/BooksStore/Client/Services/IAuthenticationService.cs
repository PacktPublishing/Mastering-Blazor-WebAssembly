namespace BooksStore.Client.Services;

public interface IAuthenticationService
{
	Task<LoginResponse> LoginUserAsync(LoginRequest requestModel);
}
