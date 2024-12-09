using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Proto;

namespace BlazorApp1.Managers;

public interface IItemManager
{
    Task<IEnumerable <Item>> GetItemsAsync(ItemDTOs itemDtos);
    Task<ItemDTOs> GetItemAsync(int id);
    Task<Category> GetCategoryAsync(int CategoryId);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task <IEnumerable<ItemDTOs>> GetItemsAsync();
  
    
    
}