using DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages;

public class DisplayProductsBase:ComponentBase
{
    [Parameter]
    public IEnumerable<ItemDTOs> Products { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }
}