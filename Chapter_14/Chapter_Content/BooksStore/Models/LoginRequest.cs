using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class LoginRequest
{

	[Required]
	[JsonPropertyName("username")]
	public string Username { get; set; } = string.Empty;

	[Required]
	[StringLength(16, MinimumLength = 5)]
	[JsonPropertyName("password")]
	public string Password { get; set; } = string.Empty;
}
