using DatabaseConnection;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepositoryContracts.CategoryContracts;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext context;

    public CategoryRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<Category> AddCategoryAsync(Category category)
    {
      EntityEntry<Category> entry = await context.Categories.AddAsync(category);
      await context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        if (!(await context.Categories.AnyAsync(c => c.CategoryId == category.CategoryId)))
        {
          throw new ArgumentException("Category does not exist");  
        }
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }

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

    public async Task<Category> GetSingleCategoryAsync(int id)
    {
        Category? category = await context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);

        if (category == null)
        {
            throw new ArgumentException($"Category with ID {id} not found");
        }

        return category;
    }

    public IQueryable<Category> GetCategories()
    {
     return context.Categories.AsQueryable();
    }
    public IQueryable<ItemCategory> GetCategoryItems()
    {
        return context.ItemCategories.AsQueryable();
    }
}