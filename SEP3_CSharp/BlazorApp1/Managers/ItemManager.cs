using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Managers;

/// <summary>
/// The ItemManager class is responsible for managing item-related operations.
/// It interacts with the "IItemService" to fetch item data.
/// </summary>
public class ItemManager : IItemManager
{
    private readonly IItemService itemService;

    /// <summary>
    /// Initializes a new instance of the "ItemManager" class.
    /// </summary>
    /// <param name="itemService">An instance of "IItemService" to interact with item data.</param>
    public ItemManager(IItemService itemService)
    {
        this.itemService = itemService;
    }

    /// <summary>
    /// Retrieves a single item based on the provided item ID.
    /// </summary>
    /// <param name="id">The unique identifier for the item.</param>
    public async Task<ItemDTOs> GetItemAsync(int id)
    {
        return await itemService.GetItem(id);
    }

    /// <summary>
    /// Retrieves all items.
    /// </summary>
    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await itemService.GetItems();
    }
}
