using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using Entities.Utilities;

namespace BlazorApp1.Managers;

public class CategoryManager:ICategoryManager
{
    
    private readonly AppDbContext _dbContext;
    private readonly ICategoryService categoryService;

    public CategoryManager(AppDbContext dbContext, ICategoryService categoryService)
    {
        _dbContext = dbContext;
        this.categoryService = categoryService;
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await categoryService.GetCategoriesAsync();
        
    }
}