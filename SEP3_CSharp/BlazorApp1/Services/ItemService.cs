using BlazorApp1.Components.Pages;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
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

    public async Task<IEnumerable<ItemDTOs>> GetItems()
    {
        try
        {
            var dummyItems = new List<ItemDTOs>
            {
                new ItemDTOs { itemId = 1, name = "Comfy cotton T-shirt", price = 10.00 },
                new ItemDTOs { itemId = 2, name = "Baggy jeans", price = 15.49 },
                new ItemDTOs { itemId = 3, name  = "Vegan backpack", price = 20.00 }
            };
            return dummyItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}