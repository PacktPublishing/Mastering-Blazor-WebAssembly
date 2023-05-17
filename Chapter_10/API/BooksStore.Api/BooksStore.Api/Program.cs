using BooksStore.Api.Interfaces;
using BooksStore.Api.Middleware;
using BooksStore.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<IAuthenticationService, LocalAuthenticationService>();
builder.Services.AddAuthentication(auth =>
{
	auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidAudience = "https://booksstore-masteringblazorwebassembly.com",
		ValidIssuer = "https://booksstore-masteringblazorwebassembly.com/api",
		RequireExpirationTime = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This key is to secure the access token, it doens't look like the best thing ever but let's see")),
		ValidateIssuerSigningKey = true
	};
});

var app = builder.Build();

app.UseCors(policy =>
{
    policy
       .AllowAnyHeader()
       .AllowAnyOrigin()
       .AllowAnyMethod();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
