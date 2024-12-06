using Entities;

namespace RepositoryContracts.ItemContracts;

public interface IItemRepository
{
    Task<Item> AddItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(int id);
    Task<Item> GetSingleItemAsync(int id);
    IQueryable<Item> GetItems();
}