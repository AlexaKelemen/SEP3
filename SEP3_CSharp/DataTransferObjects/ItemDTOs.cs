using Entities.Utilities;

namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for an item, containing details such as ID, name, description, price, categories, and image URL.
/// </summary>
public class ItemDTOs
{
    /// <summary>
    /// Gets or sets the unique id for the item.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the item.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the item.
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// Gets or sets the list of categories associated with the item.
    /// </summary>
    public List<Category> CategoryId { get; set; } = new List<Category>();

    /// <summary>
    /// Gets or sets the URL of the item's image.
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Initializes a new instance of the "ItemDTOs" class.
    /// </summary>
    public ItemDTOs()
    {
    }

    /// <summary>
    /// Initializes a new instance of the "ItemDTOs" class with specified details.
    /// </summary>
    /// <param name="itemId">The unique id for the item.</param>
    /// <param name="name">The name of the item.</param>
    /// <param name="description">The description of the item.</param>
    /// <param name="price">The price of the item.</param>
    /// <param name="quantity">The quantity of the item (currently unused).</param>
    /// <param name="categoryId">The list of categories associated with the item.</param>
    /// <param name="imageURL">The URL of the item's image.</param>
    public ItemDTOs(int itemId, string name, string description, float price, int quantity, List<Category> categoryId,
        string imageURL)
    {
        this.ItemId = itemId;
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.CategoryId = categoryId;
        this.ImageUrl = imageURL;
    }

    /// <summary>
    /// Determines whether the item belongs to a specified category.
    /// </summary>
    /// <param name="category">The name of the category to check.</param>
    /// <returns><c>true</c> if the item belongs to the category; otherwise, <c>false</c>.</returns>
    public bool HasCategory(string category)
    {
        foreach (var categoryid in CategoryId)
        {
            if (category == categoryid.CategoryName)
                return true;
        }
        return false;
    }
}
