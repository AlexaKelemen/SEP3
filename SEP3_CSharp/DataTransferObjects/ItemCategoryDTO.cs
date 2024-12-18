using Entities;
using Entities.Utilities;

namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) that links an item with its category.
/// </summary>
public class ItemCategoryDTO
{
    /// <summary>
    /// Gets or sets the item associated with this category.
    /// </summary>
    public Item ItemId { get; set; }

    /// <summary>
    /// Gets or sets the category associated with the item.
    /// </summary>
    public Category CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string CategoryName { get; set; }
}
