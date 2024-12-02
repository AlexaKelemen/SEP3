using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Microsoft.AspNetCore.Components;
using Proto;

namespace BlazorApp1.Components.Pages;

public class ProductBase: ComponentBase
{
    [Inject]
    public IItemService ItemService { get; set; }
    
    public IEnumerable<ItemDTOs> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ItemService.GetItems();
    }
}