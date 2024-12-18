using Entities.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts.CategoryContracts;
using RepositoryContracts.ItemContracts;

namespace WebAPI.Controllers;

/// <summary>
/// Controller for managing categories. Provides endpoints for retrieving single categories,
/// all categories, and category-item relationships.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;

    /// <summary>
    /// Initializes a new instance of the "CategoryController" class.
    /// </summary>
    /// <param name="categoryRepository">The repository used to interact with category data.</param>
    public CategoryController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Gets a single category by its ID.
    /// </summary>
    /// <param name="categoryId">The unique identifier of the category to retrieve.</param>
    /// <returns>An action result containing the requested category or a 404 if not found.</returns>
    [HttpGet("categories/{categoryId}")]
    public async Task<IResult> GetCategoryByIdAsync([FromRoute] int categoryId)
    {
        try
        {
            Category result = await categoryRepository.GetSingleCategoryAsync(categoryId);
            return Results.Ok(result);  // Returns 200 OK with the category.
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);  // Returns 404 Not Found if the category is not found.
        }
    }

    /// <summary>
    /// Gets all categories from the repository.
    /// </summary>
    /// <returns>An action result containing a list of all categories.</returns>
    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoryAsync()
    {
        List<Category> categories = await categoryRepository.GetCategories().ToListAsync();
        return Ok(categories);  // Returns 200 OK with a list of all categories.
    }

    /// <summary>
    /// Gets all category-item relationships from the repository.
    /// </summary>
    /// <returns>An action result containing a list of category-item relationships.</returns>
    [HttpGet("itemCategories")]
    public async Task<ActionResult<IEnumerable<ItemCategory>>> GetCategoryItemAsync()
    {
        List<ItemCategory> itemCategories = await categoryRepository.GetCategoryItems().ToListAsync();
        return Ok(itemCategories);  // Returns 200 OK with a list of category-item relationships.
    }
}
