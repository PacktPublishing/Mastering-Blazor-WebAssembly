using System.Text.Json.Serialization;

public class LoginResponse
{
	[JsonPropertyName("token")]
	public string? AccessToken { get; set; }

	[JsonPropertyName("refreshToken")]
	public string? RefreshToken { get; set; }
}