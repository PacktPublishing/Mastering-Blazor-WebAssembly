using BooksStore;
using BooksStore.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AuthorizationMessageHandler>();
builder.Services.AddHttpClient("BooksStore.ServerAPI", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
	.AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BooksStore.ServerAPI")); 

//builder.Services.AddScoped<IBooksService, LocalBooksService>();
builder.Services.AddScoped<IBooksService, BooksHttpClientService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AppStateContainer>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//builder.Services.AddApiAuthorization(); // Used up to section 3
builder.Services.AddAuthorizationCore(options =>
{
	options.AddPolicy("UK_Customer", policy =>
	{
		policy.RequireClaim(ClaimTypes.Country, "UK");
	});
});
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
await builder.Build().RunAsync();
