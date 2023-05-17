using BooksStore.Models;

namespace BooksStore.Exceptions;

public class ApiResponseException : Exception
{

	public ApiErrorResponse ErrorDetails { get; set; }

	public ApiResponseException(ApiErrorResponse errorDetails) : base(errorDetails.Message)
	{
		ErrorDetails = errorDetails;
	}

}
