using System.Text.Json;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

/// <summary>
/// A service that handles HTTP requests for managing categories. 
/// Provides methods to retrieve all categories, a single category by ID, and item-category relationships.
/// </summary>
public class HttpCategoryService : ICategoryService
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpCategoryService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HTTP client instances.</param>
    public HttpCategoryService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Products");
    }

    /// <summary>
    /// Retrieves all categories from the API.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("Category/categories");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString + " " + response.StatusCode);
        }

        return JsonSerializer.Deserialize<List<Category>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    /// <summary>
    /// Retrieves a single category by its ID from the API.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve.</param>
    /// <returns>The requested category.</returns>
    public async Task<Category> GetCategory(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"categories/{id}");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonSerializer.Deserialize<Category>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    /// <summary>
    /// Retrieves all item-category relationships from the API.
    /// </summary>
    /// <returns>A list of all item-category relationships.</returns>
    public async Task<IEnumerable<ItemCategory>> GetItemCategories()
    {
        HttpResponseMessage response = await httpClient.GetAsync("Category/itemCategories");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString + " " + response.StatusCode);
        }

        return JsonSerializer.Deserialize<List<ItemCategory>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
