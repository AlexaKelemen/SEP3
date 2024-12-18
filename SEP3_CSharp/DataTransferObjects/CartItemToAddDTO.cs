namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for adding an item to a cart, 
/// containing the cart ID, item ID, and the quantity to be added.
/// </summary>
public class CartItemToAddDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the cart.
    /// </summary>
    public int CartId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the item to be added.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item to be added to the cart.
    /// </summary>
    public int Quantity { get; set; }
}
