using Entities;
using Entities.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts.CategoryContracts;
using RepositoryContracts.ItemContracts;

namespace WebAPI2.Controllers;

/// <summary>
/// Controller for managing items. Provides endpoints for retrieving single items and all items.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    /// <summary>
    /// Initializes a new instance of the "ItemController" class.
    /// </summary>
    /// <param name="itemRepository">The repository used to interact with item data.</param>
    public ItemController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    /// <summary>
    /// Gets a single item by its ID.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to retrieve.</param>
    /// <returns>An action result containing the requested item or a 404 if not found.</returns>
    [HttpGet("items/{itemId}")]
    public async Task<IResult> GetItemByIdAsync([FromRoute] int itemId)
    {
        try
        {
            Item result = await _itemRepository.GetSingleItemAsync(itemId);
            return Results.Ok(result);  // Returns 200 OK with the item.
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);  // Returns 404 Not Found if the item is not found.
        }
    }

    /// <summary>
    /// Gets all items in the repository.
    /// </summary>
    /// <returns>An action result containing a list of all items.</returns>
    [HttpGet("items")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        List<Item> items = await _itemRepository.GetItems().ToListAsync();
        return Ok(items);  // Returns 200 OK with a list of all items.
    }
}

