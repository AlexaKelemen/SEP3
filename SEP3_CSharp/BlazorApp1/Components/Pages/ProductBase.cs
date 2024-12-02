using BlazorApp1.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Proto;

namespace BlazorApp1.Components.Pages;

public class ProductBase: ComponentBase
{
    [Inject]
    public IItemService ItemService { get; set; }
    
    public IEnumerable<ItemDTO> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ItemService.GetItems();
    }
}