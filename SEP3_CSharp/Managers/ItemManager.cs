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
        return await _context.Items.Where(i => i.ItemId == itemDTOs.getItemId()).ToListAsync();
    }


    public Task<Item> GetItem(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategory(int CategoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategories()
    {
        throw new NotImplementedException();
    }
}