using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Register the services that are common between the Blazor app and the server
builder.Services.AddSingleton<HttpClient>(sp =>
{
	// Get the address that the app is currently running at
	var server = sp.GetRequiredService<IServer>();
	var addressFeature = server.Features.Get<IServerAddressesFeature>();
	string baseAddress = addressFeature.Addresses.First();
	return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
// Map the fallback to the _Host page
app.MapFallbackToPage("/_Host");

app.Run();
