using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Proto;

namespace BlazorApp1.Managers;

/// <summary>
/// Defines the operations for managing items.
/// </summary>
public interface IItemManager
{
    /// <summary>
    /// Retrieves a specific item by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    Task<ItemDTOs> GetItemAsync(int id);

    /// <summary>
    /// Retrieves a list of all items asynchronously.
    /// </summary>
    Task<IEnumerable<ItemDTOs>> GetItemsAsync();
}
