using Entities.Utilities;

namespace BlazorApp1.Managers;

/// <summary>
/// Defines the operations for managing categories and item-category.
/// </summary>
public interface ICategoryManager
{
    /// <summary>
    /// Retrieves a list of all categories asynchronously.
    /// </summary>
    Task<IEnumerable<Category>> GetCategoriesAsync();

    /// <summary>
    /// Retrieves a list of all item-category associations asynchronously.
    /// </summary>
    Task<IEnumerable<ItemCategory>> GetItemCategoriesAsync();
}
