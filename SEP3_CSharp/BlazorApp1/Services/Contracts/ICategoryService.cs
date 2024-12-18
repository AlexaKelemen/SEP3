using Entities.Utilities;

namespace BlazorApp1.Services.Contracts;

/// <summary>
/// Defines the contract for a service that manages category-related operations.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Retrieves a list of all categories.
    /// </summary>
    /// <returns>A collection of category details.</returns>
    Task<IEnumerable<Category>> GetCategoriesAsync();

    /// <summary>
    /// Retrieves a specific category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>The details of the specified category.</returns>
    Task<Category> GetCategory(int id);

    /// <summary>
    /// Retrieves a list of item-category relationships.
    /// </summary>
    /// <returns>A collection of item-category relationship details.</returns>
    Task<IEnumerable<ItemCategory>> GetItemCategories();
}
