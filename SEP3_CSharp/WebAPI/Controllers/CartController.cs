using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.CartContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpGet("{cartId}")]
    public async Task<IResult> GetCartByIdAsync([FromRoute] int cartId)
    {
        try
        {
            Cart result = await _cartRepository.GetSingleCartAsync(cartId);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetCartsAsync()
    {
        try
        {
            var carts = _cartRepository.GetCarts().ToList();
            return Results.Ok(carts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.BadRequest(e.Message);
        }
    }

    [HttpPost("{cartId}/items")]
    public async Task<IResult> AddItemToCartAsync([FromRoute] int cartId,
        [FromBody] Item item)
    {
        try
        {
            var result = await _cartRepository.AddItemToCartAsync(cartId, item);
            return Results.Created($"/cart/{cartId}", result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.BadRequest(e.Message);
        }
    }

    [HttpDelete("{cartId}/items/{itemId}")]
    public async Task<IResult> RemoveItemFromCartAsync([FromRoute] int cartId,
        [FromRoute] int itemId)
    {
        try
        {
            await _cartRepository.RemoveItemFromCartAsync(cartId, itemId);
            return Results.NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }

    [HttpDelete("{cartId}/clear")]
    public async Task<IResult> ClearCartAsync([FromRoute] int cartId)
    {
        try
        {
            await _cartRepository.ClearCartAsync(cartId);
            return Results.NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }

    [HttpGet("{cartId}/items")]
    public async Task<IResult> GetItemsInCartAsync([FromRoute] int cartId)
    {
        try
        {
            var items = await _cartRepository.GetItemsInCartAsync(cartId);
            return Results.Ok(items.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Results.NotFound(e.Message);
        }
    }
}

