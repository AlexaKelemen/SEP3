using Entities;
using Entities.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts.CategoryContracts;
using RepositoryContracts.ItemContracts;

namespace WebAPI2.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
      
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("items/{itemId}")]
        public async Task<IResult> GetItemByIdAsync([FromRoute] int itemId)
        {
            try
            {
                Item result = await _itemRepository.GetSingleItemAsync(itemId);
                return Results.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Results.NotFound(e.Message);
            }
        }

        [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<User>>> GetItems()
        {
            List<Item> items = await _itemRepository.GetItems().ToListAsync();
            return Ok(items);
        }
    
    }
