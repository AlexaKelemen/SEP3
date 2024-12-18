using Entities.Utilities;

namespace RepositoryContracts.CategoryContracts;

/// <summary>
/// Provides methods to manage categories, including adding, updating, deleting, 
/// and retrieving categories and their associated items.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Adds a new category to the repository.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>A task that returns the added category.</returns>
    Task<Category> AddCategoryAsync(Category category);

    /// <summary>
    /// Updates an existing category in the repository.
    /// </summary>
    /// <param name="category">The category with updated details.</param>
    /// <returns>A task representing the update operation.</returns>
    Task UpdateCategoryAsync(Category category);

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>A task representing the delete operation.</returns>
    Task DeleteCategoryAsync(int id);

    /// <summary>
    /// Gets a single category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>A task that returns the requested category.</returns>
    Task<Category> GetSingleCategoryAsync(int id);

    /// <summary>
    /// Gets all categories in the repository.
    /// </summary>
    /// <returns>A queryable collection of all categories.</returns>
    IQueryable<Category> GetCategories();

    /// <summary>
    /// Gets all category-item relationships.
    /// </summary>
    /// <returns>A queryable collection of category-item associations.</returns>
    IQueryable<ItemCategory> GetCategoryItems();
}
