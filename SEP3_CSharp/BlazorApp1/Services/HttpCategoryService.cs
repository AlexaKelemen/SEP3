using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services;

public class HttpCategoryService: ICategoryService
{
    private readonly AppDbContext _appDbContext;
    private readonly HttpClient httpClient;

    public HttpCategoryService(AppDbContext appDbContext,  IHttpClientFactory httpClientFactory)
    {
        _appDbContext = appDbContext;
        httpClient = httpClientFactory.CreateClient("Products");
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _appDbContext.Categories.Select(category => new Category
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName,
            CategoryDescription = category.CategoryDescription
        }).ToListAsync();
    }
}