using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Proto;

namespace Managers;

public class ItemManager:IItemManager
{
    
    public Task<IEnumerable<Item>> GetItems(ItemDTOs itemDTOs)
    {
        throw new NotImplementedException();
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