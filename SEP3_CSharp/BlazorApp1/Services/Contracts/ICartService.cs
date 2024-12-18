using DataTransferObjects;

namespace BlazorApp1.Services.Contracts;

/// <summary>
/// Defines the contract for a service that manages shopping cart-related operations.
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Adds an item to the shopping cart.
    /// </summary>
    /// <param name="cartItemToAddDto">The item details to be added to the cart.</param>
    /// <returns>The details of the added cart item, or null if not added.</returns>
    Task<CartItemDTO?> AddItem(CartItemToAddDTO cartItemToAddDto);

    /// <summary>
    /// Deletes an item from the shopping cart by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to be removed from the cart.</param>
    /// <returns>The details of the deleted cart item, or null if not found.</returns>
    Task<CartItemDTO?> DeleteItem(int id);

    /// <summary>
    /// Retrieves all items in the shopping cart for a specified user.
    /// </summary>
    /// <param name="userId">The ID of the user whose cart items are to be retrieved.</param>
    /// <returns>A list of cart item details.</returns>
    Task<List<CartItemDTO>?> GetItems(int userId);

    /// <summary>
    /// Event triggered when the shopping cart is changed (e.g., item added or removed).
    /// </summary>
    event Action<int> OnCartChanged;

    /// <summary>
    /// Raises the event to notify about a change in the shopping cart, passing the updated total quantity.
    /// </summary>
    /// <param name="totalQty">The total quantity of items in the cart after the change.</param>
    void RaiseEventOnCartChanged(int totalQty);
}
