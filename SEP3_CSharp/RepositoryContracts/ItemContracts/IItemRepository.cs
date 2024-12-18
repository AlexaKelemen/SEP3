using Entities;

namespace RepositoryContracts.ItemContracts;

/// <summary>
/// Defines the interface for a repository that manages items, providing methods 
/// for adding, updating, deleting, and retrieving items.
/// </summary>
public interface IItemRepository
{
    /// <summary>
    /// Adds a new item to the repository asynchronously.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added item.</returns>
    Task<Item> AddItemAsync(Item item);

    /// <summary>
    /// Updates an existing item in the repository asynchronously.
    /// </summary>
    /// <param name="item">The item with updated values.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateItemAsync(Item item);

    /// <summary>
    /// Deletes an item from the repository asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the item to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteItemAsync(int id);

    /// <summary>
    /// Retrieves a single item by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the item to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the retrieved item.</returns>
    Task<Item> GetSingleItemAsync(int id);

    /// <summary>
    /// Retrieves a queryable collection of all items in the repository.
    /// </summary>
    /// <returns>An <see cref="IQueryable{T}"/> that represents the collection of items.</returns>
    IQueryable<Item> GetItems();
}
