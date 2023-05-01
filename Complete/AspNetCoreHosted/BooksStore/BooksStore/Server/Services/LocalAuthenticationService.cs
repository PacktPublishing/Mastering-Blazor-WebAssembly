using BooksStore.Server.Exceptions;
using BooksStore.Server.Interfaces;
using BooksStore.Server.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace BooksStore.Server.Services
{
	public class LocalAuthenticationService : IAuthenticationService
	{


		private static List<User> _users = new()
		{
			new User(Guid.NewGuid(), "John", "Smith", "admin@masteringblazor.com", "Test.123", "Admin", "US"),
			new User(Guid.NewGuid(), "Ahmad", "Mozaffar", "ahmad.mozaffar@masteringblazor.com", "Test.123", "Customer", "UK"),
		};

		public Task<LoginResponse> LoginAsync(LoginRequest model)
		{
			ArgumentNullException.ThrowIfNull(model);

			var user = _users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
			if (user == null)
			{
				throw new DomainException("Invalid username or password");
			}

			var token = GenerateJwtToken(user);

			return Task.FromResult(new LoginResponse
			{
				AccessToken = token
			});
		}

		private string GenerateJwtToken(User user)
		{
			var claims = new[]
			{
				new Claim(ClaimTypes.Email, user.Username),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.GivenName, user.FirstName),
				new Claim(ClaimTypes.Surname, user.LastName),
				new Claim(ClaimTypes.Role, user.Role),
				new Claim(ClaimTypes.Country, user.Country),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This key is to secure the access token, it doens't look like the best thing ever but let's see"));

			var token = new JwtSecurityToken(
				issuer: "BooksStore.Server",
				audience: "booksstore.customers",
				claims: claims,
				expires: DateTime.Now.AddDays(30),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

	internal record User(Guid Id, string FirstName, string LastName, string Username, string Password, string Role, string Country);
}
