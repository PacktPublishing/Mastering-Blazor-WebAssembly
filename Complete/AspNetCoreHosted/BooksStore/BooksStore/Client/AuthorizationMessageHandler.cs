using Blazored.LocalStorage;

namespace BooksStore.Client;

public class AuthorizationMessageHandler : DelegatingHandler
{

	private readonly ILocalStorageService _localStorage;

	public AuthorizationMessageHandler(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (await _localStorage.ContainKeyAsync("access_token"))
		{
			var token = await _localStorage.GetItemAsync<string>("access_token");
			request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
		}
		
		return await base.SendAsync(request, cancellationToken);
	}
}
