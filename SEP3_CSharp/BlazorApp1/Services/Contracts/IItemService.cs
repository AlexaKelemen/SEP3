using BlazorApp1.Components.Pages;
using DataTransferObjects;
using Proto;

namespace BlazorApp1.Services.Contracts;

public interface IItemService
{
    Task<IEnumerable<ItemDTOs>> GetItems();
    Task<ItemDTOs> GetItem(int id);
   /* Task<IEnumerable<ItemCategoryDTO>> GetProductCategories();
    Task<IEnumerable<ItemDTOs>> GetItemsByCategory(int CategoryId);*/
    
}