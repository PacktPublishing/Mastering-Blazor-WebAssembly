using BooksStore.Client.Models;
using BooksStore.Shared.Models;

namespace BooksStore.Client.Exceptions;

public class ApiResponseException : Exception
{

	public ApiErrorResponse ErrorDetails { get; set; }

	public ApiResponseException(ApiErrorResponse errorDetails) : base(errorDetails.Message)
	{
		ErrorDetails = errorDetails;
	}

}
