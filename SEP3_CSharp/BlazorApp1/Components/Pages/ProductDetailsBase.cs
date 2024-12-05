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
        public IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

        [Inject]
        public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ItemDTO Item { get; set; }

        public string ErrorMessage { get; set; }

        private List<CartItemDTO> ShoppingCartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                Item = await GetProductById(Id);
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

        private async Task<ItemDTO> GetProductById(int id)
        {
            var productDtos = await ManageProductsLocalStorageService.GetCollection();

            if(productDtos!=null)
            {
                return productDtos.SingleOrDefault(p => p.Id == id);
            }
            return null;
        }

    }
