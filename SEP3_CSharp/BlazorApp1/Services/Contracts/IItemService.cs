using BlazorApp1.Components.Pages;
using Proto;

namespace BlazorApp1.Services.Contracts;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetItems();
}