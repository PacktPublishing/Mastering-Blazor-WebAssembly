using BooksStore.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BooksStore.Client.Services;

public class BooksHttpClientService : IBooksService
{
	
	private readonly HttpClient _httpClient;

	public BooksHttpClientService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task AddBookAsync(SubmitBook book)
	{
		var response = await _httpClient.PostAsJsonAsync("books", book);
		if (!response.IsSuccessStatusCode)
		{
			var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			Console.WriteLine(error);
		}
	}

	public async Task<List<Book>?> GetAllBooksAsync()
	{
		var response = await _httpClient.GetAsync("books");
		if (response.IsSuccessStatusCode) // if response status code is 2XX
		{
			return await response.Content.ReadFromJsonAsync<List<Book>>();
		}
		else
		{
			var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			// Throw an exception with the error message for now
			throw new Exception(errorResponse?.Message);
			// TODO: Handle the error in Chapter 11
		}
	}

	public async Task<Book?> GetBookByIdAsync(string? id)
	{
		var response = await _httpClient.GetAsync($"/books/{id}");
		Console.WriteLine(await response.Content.ReadAsStringAsync());
		if (response.IsSuccessStatusCode) // if response status code is 2XX
		{
			return await response.Content.ReadFromJsonAsync<Book>();
		}
		else
		{
			var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			throw new Exception(errorResponse?.Message);
		}
	}

	public async Task AddReviewAsync(string bookId, AddBookReviewRequest review)
	{
		var response = await _httpClient.PostAsJsonAsync($"books/review/{bookId}", review);
		if (!response.IsSuccessStatusCode)
		{
			var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			Console.WriteLine(error);
		}
	}

	public async Task UploadBookCoverAsync(string bookId, Stream stream, string fileName)
	{
		using var content = new MultipartFormDataContent();
		using var fileContent = new StreamContent(stream);
		fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
		{
			Name = "file",
			FileName = fileName
		};
		content.Add(fileContent);
		var response = await _httpClient.PostAsync($"/books/{bookId}/cover", content);
		if (!response.IsSuccessStatusCode)
		{
			var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
			Console.WriteLine(error);
		}
	}
}