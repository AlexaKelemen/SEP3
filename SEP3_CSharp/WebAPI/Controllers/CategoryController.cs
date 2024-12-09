using Entities.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts.CategoryContracts;
using RepositoryContracts.ItemContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("{categoryId}")]
    public async Task<IResult> GetCategoryByIdAsync([FromRoute] int categoryId)
    {
        try
        {
          Category result = await _categoryRepository.GetSingleCategoryAsync(categoryId);
          return Results.Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }

    [HttpGet("{categories}")]
    public async Task<IResult> GetCategory()
    {
        Task<List<Category>> categories = _categoryRepository.GetCategories().ToListAsync();
        return Results.Ok(categories);
    }
    
}