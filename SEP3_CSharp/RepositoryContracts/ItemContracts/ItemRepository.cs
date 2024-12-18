using DatabaseConnection;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepositoryContracts.ItemContracts;

/// <summary>
/// Implements methods to manage items, including adding, updating, deleting, 
/// and retrieving items from the repository.
/// </summary>
public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _ctx;

    /// <summary>
    /// Initializes a new instance of the "ItemRepository" class.
    /// </summary>
    /// <param name="ctx">The database context used to interact with items.</param>
    public ItemRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    /// <summary>
    /// Adds a new item to the repository.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <returns>The added item.</returns>
    public async Task<Item> AddItemAsync(Item item)
    {
        EntityEntry<Item> entityEntry = await _ctx.Items.AddAsync(item);
        await _ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    /// <summary>
    /// Updates an existing item in the repository.
    /// </summary>
    /// <param name="item">The item with updated details.</param>
    /// <exception cref="ArgumentException">Thrown when the item does not exist.</exception>
    public async Task UpdateItemAsync(Item item)
    {
        if (!(await _ctx.Items.AnyAsync(i => i.ItemId == item.ItemId)))
        {
            throw new ArgumentException($"Item with id {item.ItemId} not found");
        }
        _ctx.Items.Update(item);
        await _ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an item from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <exception cref="ArgumentException">Thrown when the item is not found.</exception>
    public async Task DeleteItemAsync(int id)
    {
        Item? existing = await _ctx.Items.SingleOrDefaultAsync(i => i.ItemId == id);
        if (existing == null)
        {
            throw new ArgumentException($"Item with id {id} not found");
        }

        _ctx.Items.Remove(existing);
        await _ctx.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves an item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The requested item.</returns>
    /// <exception cref="ArgumentException">Thrown when the item is not found.</exception>
    public async Task<Item> GetSingleItemAsync(int id)
    {
        Item? item = await _ctx.Items.SingleOrDefaultAsync(i => i.ItemId == id);

        if (item == null)
        {
            throw new ArgumentException($"Item with ID {id} not found");
        }

        return item;
    }

    /// <summary>
    /// Retrieves all items from the repository.
    /// </summary>
    /// <returns>A queryable collection of all items.</returns>
    public IQueryable<Item> GetItems()
    {
        return _ctx.Items.AsQueryable();
    }
}
