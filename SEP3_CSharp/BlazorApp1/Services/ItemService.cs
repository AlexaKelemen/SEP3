using BlazorApp1.Components.Pages;
using BlazorApp1.Services.Contracts;
using Entities;
using Proto;

namespace BlazorApp1.Services;

public class ItemService : IItemService
{
    private readonly HttpClient _httpClient;

    public ItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ItemDTO>> GetItems()
    {
        try
        {
            var products = await this._httpClient.GetFromJsonAsync<IEnumerable<ItemDTO>>("api/Product");
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}