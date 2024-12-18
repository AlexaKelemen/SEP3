namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for an item in the cart, 
/// </summary>
public class CartItemDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the item.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Gets or sets the color of the item.
    /// </summary>
    public string Colour { get; set; }

    /// <summary>
    /// Gets or sets the size of the item.
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// Gets or sets the price of the item.
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the item.
    /// </summary>
    /// <remarks>
    /// This property is required and cannot be null.
    /// </remarks>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    /// <remarks>
    /// This property is required and cannot be null.
    /// </remarks>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quantity of the item in the cart.
    /// </summary>
    public int Quantity { get; set; }
}
