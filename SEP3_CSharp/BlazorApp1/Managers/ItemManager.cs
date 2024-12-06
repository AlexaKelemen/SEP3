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

    public ItemManager(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Item>> GetItems(ItemDTOs itemDTOs)
    {
        return await _dbContext.Items.ToListAsync();
    }


    public async Task<ItemDTOs> GetItem(int id)
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

    public async Task<Category> GetCategory(int CategoryId)
    {
      return await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
       return await _dbContext.Categories.ToListAsync();
    }
}