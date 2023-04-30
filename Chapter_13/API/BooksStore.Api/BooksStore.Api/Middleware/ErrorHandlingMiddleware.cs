using BooksStore.Api.Exceptions;
using BooksStore.Api.Models;
using System.Net;
using System.Text.Json;

namespace BooksStore.Api.Middleware
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorHandlingMiddleware> _logger;
		public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex, _logger);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddleware> logger)
		{
			var code = HttpStatusCode.InternalServerError;

			var result = new ApiErrorResponse();

			switch (exception)
			{
				case DomainException ex:
					code = HttpStatusCode.BadRequest;
					result = new ApiErrorResponse()
					{
						Message = exception.Message,
						Errors = ex.Errors
					};
					break;
				case Exception e:
					logger.LogError(exception, "SERVER ERROR");
					code = HttpStatusCode.InternalServerError;
					result = new ApiErrorResponse()
					{
						Message = "Something went wrong"
					};
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			string jsonResponse = JsonSerializer.Serialize(result);

			await context.Response.WriteAsync(jsonResponse);
		}
	}
}
