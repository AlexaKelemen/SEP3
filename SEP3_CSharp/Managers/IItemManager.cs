using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Proto;

namespace Managers;

public interface IItemManager
{
    Task<IEnumerable <Item>> GetItems(ItemDTOs itemDtos);
    Task<Item> GetItem(string id);
    Task<Category> GetCategory(int CategoryId);
    Task<IEnumerable<Category>> GetCategories();
  
    
    
}