using System.Text;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;

namespace BlazorApp1.Services;

/// <summary>
/// A service that handles HTTP requests for managing shopping cart items. 
/// Provides methods to add, delete, and retrieve items from the shopping cart.
/// </summary>
public class HttpCartService : ICartService
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Event triggered when the shopping cart is changed.
    /// </summary>
    public event Action<int> OnShoppingCartChanged;

    /// <summary>
    /// Initializes a new instance of the "HttpCartService" class.
    /// </summary>
    /// <param name="httpClientFactory">Factory for creating HTTP client instances.</param>
    public HttpCartService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("Products");
    }

    /// <summary>
    /// Adds an item to the shopping cart.
    /// </summary>
    /// <param name="cartItemToAddDto">The cart item details to be added.</param>
    /// <returns>The added cart item or null if no content is returned.</returns
    public async Task<CartItemDTO?> AddItem(CartItemToAddDTO cartItemToAddDto)
    {
        var response = await httpClient.PostAsJsonAsync("api/ShoppingCart", cartItemToAddDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(CartItemDTO); // No content returned
            }

            return await response.Content.ReadFromJsonAsync<CartItemDTO>(); // Return the added item
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception($"Http status:{response.StatusCode} Message -{message}");
    }

    /// <summary>
    /// Deletes an item from the shopping cart by its ID.
    /// </summary>
    /// <param name="id">The ID of the cart item to delete.</param>
    /// <returns>The deleted cart item or null if no content is returned.</returns>
    public async Task<CartItemDTO?> DeleteItem(int id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"api/ShoppingCart/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CartItemDTO>(); // Return the deleted item
            }

            return default(CartItemDTO); // No content returned
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves all items in the shopping cart for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve the cart items for.</param>
    /// <returns>A list of cart items or an empty list if no items are found.</returns>
    public async Task<List<CartItemDTO>?> GetItems(int userId)
    {
        var response = await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CartItemDTO>().ToList(); // Return empty list if no content
            }

            return await response.Content.ReadFromJsonAsync<List<CartItemDTO>>(); // Return list of cart items
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
    }

    public event Action<int>? OnCartChanged;

    /// <summary>
    /// Event triggered to notify that the cart has changed.
    /// </summary>
    /// <param name="totalQty">The total quantity of items in the cart.</param>
    public void RaiseEventOnCartChanged(int totalQty)
    {
        OnShoppingCartChanged?.Invoke(totalQty); 
    }
}
