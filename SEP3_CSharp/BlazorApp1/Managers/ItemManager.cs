using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Managers;

public class ItemManager:IItemManager
{
    private readonly AppDbContext _dbContext;
    private readonly IItemService itemService;

    public ItemManager(AppDbContext dbContext, IItemService itemService)
    {
        _dbContext = dbContext;
        this.itemService = itemService;
    }
    public async Task<IEnumerable<Item>> GetItemsAsync(ItemDTOs itemDTOs)
    {
        return await _dbContext.Items.ToListAsync();
    }


    public async Task<ItemDTOs> GetItemAsync(int id)
    {
        Item item = new Item();
        try
        {
            item = await _dbContext.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        

        ItemDTOs itemDTO = new ItemDTOs()
        {
            ItemId = item.ItemId,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            CategoryId = item.CategoryId,
            ImageUrl = item.ImageURL

        };
        return itemDTO;
    }

    public async Task<Category> GetCategoryAsync(int CategoryId)
    {
      return await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
       return await _dbContext.Categories.ToListAsync();
    }
    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await itemService.GetItems();
    }
}