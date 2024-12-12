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
    private readonly ICategoryRepository categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    [HttpGet("categories/{categoryId}")]
    public async Task<IResult> GetCategoryByIdAsync([FromRoute] int categoryId)
    {
        try
        {
            Category result = await categoryRepository.GetSingleCategoryAsync(categoryId);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoryAsync()
    {
        List<Category> categories = await categoryRepository.GetCategories().ToListAsync();
        return Ok(categories);
    }

    [HttpGet("itemCategories")]
    public async Task<ActionResult<IEnumerable<ItemCategory>>> GetCategoryItemAsync()
    {
        List<ItemCategory> itemCategories = await categoryRepository.GetCategoryItems().ToListAsync();
        return Ok(itemCategories);
    }
}