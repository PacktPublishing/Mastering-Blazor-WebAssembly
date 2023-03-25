using BooksStore.Models;
using System.Net.Http.Json;

namespace BooksStore.Services;

public class AuthenticationService : IAuthenticationService
{

	// Inject the HttpClient into the constructor
	private readonly HttpClient _httpClient;

	public AuthenticationService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<LoginResponse> LoginUserAsync(LoginRequest requestModel)
	{
		var response = await _httpClient.PostAsJsonAsync("authentication/login", requestModel);
		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<LoginResponse>();
		}
		else
		{
			var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			Console.WriteLine(error);
			throw new Exception(error.Message);
			// TODO: Handle the error in a proper way 
		}
	}
}