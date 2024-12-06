using DatabaseConnection;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepositoryContracts.CategoryContracts;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Category> AddCategoryAsync(Category category)
    {
      EntityEntry<Category> entry = await _context.Categories.AddAsync(category);
      await _context.SaveChangesAsync();
      return entry.Entity;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        if (!(await _context.Categories.AnyAsync(c => c.CategoryId == category.CategoryId)))
        {
          throw new ArgumentException("Category does not exist");  
        }
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        Category? existing = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        if (existing == null)
        {
            throw new ArgumentException($"Category with id {id} not found");
        }

        _context.Categories.Remove(existing);
        await _context.SaveChangesAsync();
    }

    public async Task<Category> GetSingleCategoryAsync(int id)
    {
        Category? category = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);

        if (category == null)
        {
            throw new ArgumentException($"Category with ID {id} not found");
        }

        return category;
    }

    public IQueryable<Category> GetCategories()
    {
     return _context.Categories.AsQueryable();
    }
}