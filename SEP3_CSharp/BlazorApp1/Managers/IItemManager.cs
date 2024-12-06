using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Proto;

namespace BlazorApp1.Managers;

public interface IItemManager
{
    Task<IEnumerable <Item>> GetItems(ItemDTOs itemDtos);
    Task<ItemDTOs> GetItem(int id);
    Task<Category> GetCategory(int CategoryId);
    Task<IEnumerable<Category>> GetCategories();
  
    
    
}