using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Microsoft.AspNetCore.Components;
using Proto;

namespace BlazorApp1.Components.Pages;

public class ProductDetailsBase
{
    [Parameter]
        public int Id { get; set; }

        [Inject]
        public IItemService itemService { get; set; }

        [Inject]
        public ICartService cartService { get; set; }
        

        [Inject]
        public IManageItemsLocalStorageService ManageItemsLocalStorageService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ItemDTOs Item { get; set; }

        public string ErrorMessage { get; set; }

        private List<CartItemDTO> ShoppingCartItems { get; set; }

        protected async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                var product = await GetProductById(Id);
                if (product != null)
                {
                    Item = new ItemDTOs()
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ImageUrl = product.ImageUrl
                    };
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDTO cartItemToAddDto)
        {
            try
            {
               var cartItemDto = await cartService.AddItem(cartItemToAddDto);

                if (cartItemDto != null)
                {
                    ShoppingCartItems.Add(cartItemDto);
                    await ManageCartItemsLocalStorageService.SaveCollection(ShoppingCartItems);
                }

               NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

                //Log Exception
            }
        }

        private async Task<DataTransferObjects.ItemDTOs> GetProductById(int id)
        {
            var productDtos = await ManageItemsLocalStorageService.GetCollection();

            if (productDtos != null)
            {
                var itemDto = productDtos.SingleOrDefault(p => p.ItemId == id);

                if (itemDto != null)
                {
                    return itemDto; // Return directly since it's already the correct type
                }
            }

            return null;
        }

    }
