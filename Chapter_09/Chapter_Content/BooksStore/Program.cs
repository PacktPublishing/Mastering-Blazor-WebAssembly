using BooksStore;
using BooksStore.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });
builder.Services.AddScoped<DemoLoggingHandler>(); 
builder.Services.AddHttpClient("BooksStore.API", httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
                 .AddHttpMessageHandler<DemoLoggingHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BooksStore.API")); 
//builder.Services.AddScoped<IBooksService, LocalBooksService>();
builder.Services.AddScoped<IBooksService, BooksHttpClientService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<AppStateContainer>(); 

await builder.Build().RunAsync();
