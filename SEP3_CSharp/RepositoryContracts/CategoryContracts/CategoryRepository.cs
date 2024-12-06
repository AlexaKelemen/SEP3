using Entities.Utilities;

namespace RepositoryContracts.CategoryContracts;

public class CategoryRepository : ICategoryRepository
{
   private List<Category> categories;
    public Task<Category> AddCategoryAsync(Category category)
    {
      category.CategoryId = categories.Any() ? categories.Max(c => c.CategoryId) + 1 : 1;
      categories.Add(category);
      return Task.FromResult(category);
    }

    public Task UpdateCategoryAsync(Category category)
    {
      Category categoryToUpdate = categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
      if (categoryToUpdate is null)
      {
          throw new InvalidOperationException($"Category '{category.CategoryId}' does not exist");
      }
      categories.Remove(categoryToUpdate);
      categories.Add(category);
      return Task.CompletedTask;
    }

    public Task DeleteCategoryAsync(int id)
    {
     Category categoryToDelete = categories.SingleOrDefault(c => c.CategoryId == id);
     if (categoryToDelete is null)
     {
         throw new InvalidOperationException($"Category '{categoryToDelete.CategoryId}' does not exist");
     }
     categories.Remove(categoryToDelete);
     return Task.CompletedTask;
    }

    public Task<Category> GetSingleCategoryAsync(int id)
    {
        Category? category = categories.SingleOrDefault(c => c.CategoryId == id);
        if (category is null)
        {
            throw new InvalidOperationException($"Category with Id {id} was not found");
        }
        return Task.FromResult(category);
    }

    public IQueryable<Category> GetCategories()
    {
     return categories.AsQueryable();
    }
}