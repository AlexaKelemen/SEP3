using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;
using Proto;

namespace BlazorApp1.Managers;

public class ItemManager:IItemManager
{
    private readonly IItemService itemService;

    public ItemManager(IItemService itemService)
    {
        this.itemService = itemService;
    }
    /*public async Task<IEnumerable<Item>> GetItemsAsync(ItemDTOs itemDTOs)
    {
    }*/
    
    public async Task<ItemDTOs> GetItemAsync(int id)
    {
        return await itemService.GetItem(id);
    }
    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await itemService.GetItems();
    }
}