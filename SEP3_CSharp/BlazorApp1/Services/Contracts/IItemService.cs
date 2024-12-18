using BlazorApp1.Components.Pages;
using DataTransferObjects;
using Proto;

namespace BlazorApp1.Services.Contracts;

/// <summary>
/// Defines the contract for a service that manages item-related operations.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Retrieves a list of all items.
    /// </summary>
    /// <returns>A collection of item details.</returns>
    Task<IEnumerable<ItemDTOs>> GetItems();

    /// <summary>
    /// Retrieves a specific item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The details of the specified item.</returns>
    Task<ItemDTOs> GetItem(int id);
}
