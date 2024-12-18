using DatabaseConnection;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepositoryContracts.CategoryContracts;

/// <summary>
/// Implements methods to manage categories, including adding, updating, deleting, 
/// and retrieving categories.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext context;

    /// <summary>
    /// Initializes a new instance of the "CategoryRepository" class.
    /// </summary>
    /// <param name="context">The database context used to access the categories.</param>
    public CategoryRepository(AppDbContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Adds a new category to the repository.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>The added category.</returns>
    public async Task<Category> AddCategoryAsync(Category category)
    {
        EntityEntry<Category> entry = await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return entry.Entity;
    }

    /// <summary>
    /// Updates an existing category in the repository.
    /// </summary>
    /// <param name="category">The category with updated details.</param>
    /// <exception cref="ArgumentException">Thrown when the category does not exist.</exception>
    public async Task UpdateCategoryAsync(Category category)
    {
        if (!(await context.Categories.AnyAsync(c => c.CategoryId == category.CategoryId)))
        {
            throw new ArgumentException("Category does not exist");
        }

        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <exception cref="ArgumentException">Thrown when the category is not found.</exception>
    public async Task DeleteCategoryAsync(int id)
    {
        Category? existing = await context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        if (existing == null)
        {
            throw new ArgumentException($"Category with id {id} not found");
        }

        context.Categories.Remove(existing);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>The requested category.</returns>
    /// <exception cref="ArgumentException">Thrown when the category is not found.</exception>
    public async Task<Category> GetSingleCategoryAsync(int id)
    {
        Category? category = await context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);

        if (category == null)
        {
            throw new ArgumentException($"Category with ID {id} not found");
        }

        return category;
    }

    /// <summary>
    /// Retrieves all categories from the repository.
    /// </summary>
    /// <returns>A queryable collection of all categories.</returns>
    public IQueryable<Category> GetCategories()
    {
        return context.Categories.AsQueryable();
    }

    /// <summary>
    /// Retrieves all category-item relationships from the repository.
    /// </summary>
    /// <returns>A queryable collection of category-item relationships.</returns>
    public IQueryable<ItemCategory> GetCategoryItems()
    {
        return context.ItemCategories.AsQueryable();
    }
}
