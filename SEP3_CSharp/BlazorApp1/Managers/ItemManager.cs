using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace Managers;

public class ItemManager:IItemManager
{
    private readonly ApplicationAppContext _context;

    public ItemManager(ApplicationAppContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Item>> GetItems(ItemDTOs itemDTOs)
    {
        return await _context.Items.ToListAsync();
    }


    public async Task<Item> GetItem(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(i => i.ItemId == id);
    }

    public async Task<Category> GetCategory(int CategoryId)
    {
      return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId);
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
       return await _context.Categories.ToListAsync();
    }
}