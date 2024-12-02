using BlazorApp1.Services.Contracts;
using DataTransferObjects;

namespace BlazorApp1.Services;

public class HttpCartService : ICartService

{
    private readonly HttpClient httpClient;

    public HttpCartService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CartItemDTO?> AddItem(CartItemToAddDTO cartItemToAddDto)
    {
        var response =
            await httpClient.PostAsJsonAsync<CartItemToAddDTO>(
                "api/ShoppingCart", cartItemToAddDto);

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(CartItemDTO);
            }

            return await response.Content.ReadFromJsonAsync<CartItemDTO>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(
            $"Http status:{response.StatusCode} Message -{message}");
    }

    public async Task<CartItemDTO?> DeleteItem(int id)
    {
        var response = await httpClient.DeleteAsync($"api/ShoppingCart/{id}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CartItemDTO>();
        }

        return default(CartItemDTO);
    }

    public async Task<List<CartItemDTO>?> GetItems(int userId)
    {
        var response =
            await httpClient.GetAsync($"api/ShoppingCart/{userId}/GetItems");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CartItemDTO>().ToList();
            }

            return await response.Content
                .ReadFromJsonAsync<List<CartItemDTO>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(
            $"Http status code: {response.StatusCode} Message: {message}");
    }
}