using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class SubmitBook
{
	// Title is required and value shouldn't be empty and it has to be at least 3 characters long and at most 80 characters long
	[Required]
	[StringLength(80, MinimumLength = 3)]
	public string Title { get; set; } = string.Empty;

	// Description is optional but it must be at most 5000 characters long
	[StringLength(5000)]
	public string? Description { get; set; }

	// Author is required and value shouldn't be empty and it has to be at least 3 characters long and at most 80 characters long
	[Required]
	[StringLength(80, MinimumLength = 3)]
	public string Author { get; set; } = string.Empty;

	[Range(typeof(decimal), "0", "99999")] // price decimal value must be between 0 and 99999
	public decimal Price { get; set; }

	[DisplayName("Number of Pages")]
	[Range(0, 9999, ErrorMessage = "Number of pages must be at least 0 and at most 9999")] // int value must be between 0 and 9999
	public int PagesCount { get; set; }
	
	// TODO: Other properties to be added in the next sections 
}