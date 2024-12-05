using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Microsoft.AspNetCore.Components;
using Proto;

namespace BlazorApp1.Components.Pages;

public class ProductBase: ComponentBase
{
    [Inject]
    public IItemService ItemService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    public IEnumerable<ItemDTOs> Items{ get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = await ItemService.GetItems();
    }
}