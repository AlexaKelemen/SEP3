using Entities.Utilities;

namespace BlazorApp1.Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategory(int id);
}