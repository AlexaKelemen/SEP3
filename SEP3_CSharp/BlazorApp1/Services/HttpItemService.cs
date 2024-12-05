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

    public HttpItemService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<ItemDTOs>> GetItems()
    {
        return await _appDbContext.Items.Select(item => new ItemDTOs
        {
            name = item.Name,
            price = item.Price,
            imageURL = item.ImageURL,
        }).ToListAsync();
    }

}