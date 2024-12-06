using Entities;

namespace RepositoryContracts.ItemContracts;

public class ItemRepository : IItemRepository
{
    private List<Item> items;
    
    public Task<Item> AddItemAsync(Item item)
    {
        item.ItemId = items.Any() ? items.Max(i => i.ItemId) + 1 : 1;
        items.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateItemAsync(Item item)
    {
        Item itemToUpdate = items.SingleOrDefault(i => i.ItemId == item.ItemId);
        if (itemToUpdate is null)
        {
            throw new InvalidOperationException($"Item '{item.ItemId}' does not exist");
        }
        items.Remove(itemToUpdate);
        items.Add(item);
        return Task.CompletedTask;
    }

    public Task DeleteItemAsync(int id)
    {
        Item itemToDelete = items.SingleOrDefault(i => i.ItemId == id);
        if (itemToDelete is null)
        {
            throw new InvalidOperationException($"Item '{itemToDelete.ItemId}' does not exist");
        }
        items.Remove(itemToDelete);
        return Task.CompletedTask;
    }

    public Task<Item> GetSingleItemAsync(int id)
    {
        Item item = items.SingleOrDefault(i => i.ItemId == id);
        if (item is null)
        {
            throw new InvalidOperationException($"Item with Id {id} was not found");
        }
        return Task.FromResult(item);
    }

    public IQueryable<Item> GetItems()
    {
        return items.AsQueryable();
    }
}