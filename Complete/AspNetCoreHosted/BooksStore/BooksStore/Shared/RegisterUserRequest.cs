using System.ComponentModel.DataAnnotations;

namespace BooksStore.Shared;

    public class RegisterUserRequest
    {
        [MinLength(3, ErrorMessage = "Password minimum length is 3 characters")]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

	[MinLength(3, ErrorMessage = "Username minimum length is 3 characters")]
	[Required(ErrorMessage = "Username is required")]
	public string? Username { get; set; }

	[Required(ErrorMessage = "First name is required")]
	public string? FirstName { get; set; }

	[Required(ErrorMessage = "Last name is required")]
	public string? LastName { get; set; }

	[Required(ErrorMessage = "Country is required")]
	[StringLength(2)]
	public string? Country { get; set; }
            
    }

