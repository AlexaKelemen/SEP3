using DatabaseConnection;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RepositoryContracts.ItemContracts;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _ctx;

    public ItemRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<Item> AddItemAsync(Item item)
    {
        EntityEntry<Item> entityEntry = await _ctx.Items.AddAsync(item);
        await _ctx.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateItemAsync(Item item)
    {
        if (!(await _ctx.Items.AnyAsync(i => i.ItemId == item.ItemId)))
        {
            throw new ArgumentException($"Item with id {item} not found");
        }
        _ctx.Items.Update(item);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(int id)
    {
        Item? existing = await _ctx.Items.SingleOrDefaultAsync(i => i.ItemId== id);
        if (existing == null)
        {
            throw new ArgumentException($"Post with id {id} not found");
        }

        _ctx.Items.Remove(existing);
        await _ctx.SaveChangesAsync();
    }

    public async Task<Item> GetSingleItemAsync(int id)
    {
        Item? item = await _ctx.Items.SingleOrDefaultAsync(i => i.ItemId == id);

        if (item == null)
        {
            throw new ArgumentException($"Post with ID {id} not found");
        }

        return item;
    }

    public IQueryable<Item> GetItems()
    {
        return _ctx.Items.AsQueryable();
    }
}