using Entities.Utilities;

namespace RepositoryContracts.CategoryContracts;

public interface ICategoryRepository
{
        Task<Category> AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<Category> GetSingleCategoryAsync(int id);
        IQueryable<Category> GetCategories();
    }
