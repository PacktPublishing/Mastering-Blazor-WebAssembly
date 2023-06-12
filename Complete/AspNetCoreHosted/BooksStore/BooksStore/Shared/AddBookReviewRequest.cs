using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AddBookReviewRequest
{

	[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
	public int Rating { get; set; } = 1;
	
	public string? Description { get; set; }

}

