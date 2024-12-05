﻿using BlazorApp1.Services.Contracts;
using Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Components.Pages

{
    public class ShoppingCartBaseTry : ComponentBase
    {
        [Inject] public IJSRuntime Js { get; set; }

        [Inject] public ICartService CartService { get; set; }

        protected Dictionary<int, (Entities.Item Item, int Quantity)> CartItems =
            new Dictionary<int, (Item, int)>();

        protected decimal CartTotal => (decimal)CartItems.Sum(entry =>
            entry.Value.Item.Price * entry.Value.Quantity);

        private void AddToCart(Item product, int quantity)
        {
            if (CartItems.ContainsKey(product.ItemId))
            {
                CartItems[product.ItemId] = (product,
                    CartItems[product.ItemId].Quantity + quantity);
            }
            else
            {
                CartItems[product.ItemId] = (product, quantity);
            }
        }


        protected void UpdateQuantity(int id, int quantity)
        {
            if (CartItems.ContainsKey(id) && quantity > 0)
            {
                CartItems[id] = (CartItems[id].Item, quantity);
            }
        }

        protected void RemoveFromCart(int itemId)
        {
            if (CartItems.ContainsKey(itemId))
            {
                CartItems.Remove(itemId);
            }
        }


        protected void Checkout()
        {
            CartItems.Clear();
            StateHasChanged();
        }
    }
}