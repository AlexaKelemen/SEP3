using BlazorApp1.Components.Pages;
using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Services;

public class HttpItemService : IItemService
{
    private readonly AppDbContext _appDbContext;
    private readonly HttpClient _httpClient;

    public HttpItemService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public HttpItemService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<IEnumerable<ItemDTOs>> GetItems()
    {
        return await _appDbContext.Items.Select(item => new ItemDTOs
        {
            Name = item.Name,
            Price = item.Price,
            ImageUrl = item.ImageURL,
        }).ToListAsync();
    }

    public async Task<ItemDTOs> GetItem(int id)
    {
        var item = await _appDbContext.Items
            .Where(i => i.ItemId == id)
            .Select(i => new ItemDTOs
            {
                Name = i.Name,
                Price = i.Price,
                ImageUrl = i.ImageURL,
            })
            .FirstOrDefaultAsync();

        if (item == null)
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }

        return item;
    }
/*
    public Task<IEnumerable<ProductCategoryDto>> GetProductCategories()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ItemDTOs>> GetItemsByCategory(int CategoryId)
    {
        return await _appDbContext.Items
            .Where(i => i.CategoryId ==categoryid)
            .Select(i => new ItemDTOs
            {
                Name = i.Name,
                Price = i.Price,
                ImageUrl = i.ImageURL,
            })
            .ToListAsync();
    }*/
}