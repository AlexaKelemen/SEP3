using BlazorApp1.Components.Pages;
using DataTransferObjects;
using Proto;

namespace BlazorApp1.Services.Contracts;

public interface IItemService
{
    Task<IEnumerable<ItemDTOs>> GetItems();
}