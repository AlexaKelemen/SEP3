using System.Text.Json;
using BlazorApp1.Components.Pages;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Services;

/// <summary>
/// A service that handles HTTP requests for managing items. 
/// Provides methods to retrieve all items and a single item by ID.
/// </summary>
public class HttpItemService : IItemService
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpItemService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HTTP client instances.</param>
    public HttpItemService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Products");
    }

    /// <summary>
    /// Retrieves all items from the API.
    /// </summary>
    /// <returns>A list of all items.</returns>
    public async Task<IEnumerable<ItemDTOs>> GetItems()
    {
        HttpResponseMessage response = await httpClient.GetAsync("Item/items");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString + " " + response.StatusCode);
        }

        return JsonSerializer.Deserialize<List<ItemDTOs>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    /// <summary>
    /// Retrieves a single item by its ID from the API.
    /// </summary>
    /// <param name="id">The unique identifier of the item to retrieve.</param>
    /// <returns>The requested item.</returns>
    public async Task<ItemDTOs> GetItem(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"Item/items/{id}");
        string responseString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseString);
        }

        return JsonSerializer.Deserialize<ItemDTOs>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }
}
