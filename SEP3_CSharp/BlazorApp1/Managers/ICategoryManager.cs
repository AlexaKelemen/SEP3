using Entities.Utilities;

namespace BlazorApp1.Managers;

public interface ICategoryManager
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<IEnumerable<ItemCategory>> GetItemCategoriesAsync();
}