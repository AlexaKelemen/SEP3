using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using Entities.Utilities;

namespace BlazorApp1.Managers;

public class CategoryManager:ICategoryManager
{
    private readonly ICategoryService categoryService;

    public CategoryManager( ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await categoryService.GetCategoriesAsync();
        
    }
}