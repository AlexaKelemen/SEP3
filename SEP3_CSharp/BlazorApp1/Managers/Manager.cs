using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proto;



namespace BlazorApp1.Managers;

public class Manager : IManager
{
    
    private IUserManager UserManager;
    
    private UserService.UserServiceClient stub;

    private IUserService UserService;
    
    private IItemManager ItemManager;
    
    private CategoryManager CategoryManager;
    private ICartManager CartManager;
    private OrderManager OrderManager;

    public Manager()
    {
        
    }

    public Manager(GrpcChannel channel, IUserService userService, IItemService itemService, ICategoryService categoryService)
    {
        var stub = new UserService.UserServiceClient(channel);
        
        UserManager = new UserManager(stub, userService);
        ItemManager = new ItemManager(itemService);
        CategoryManager = new CategoryManager(categoryService);
        CartManager = new CartManager();
        OrderManager = new OrderManager(stub);
    }
    public async Task<User> GetUserAsync(string username)
    {
        return await UserManager.GetUserAsync(username);
    }

    public async Task SaveUserInfoAsync(UserDTO userdto)
    {
        await UserManager.SaveUserInfoAsync(userdto);
    }

    public async Task<ItemDTOs> GetProductByIdAsync(int productId)
    {
       return await ItemManager.GetItemAsync(productId);
    }

    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await ItemManager.GetItemsAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await CategoryManager.GetCategoriesAsync();
    }

    public Dictionary<Item, int> GetCartItems()
    {
        return CartManager.GetCartItems();
    }
    

    public void AddToCart(Item addedItem, int quantity)
    {
        CartManager.AddToCart(addedItem, quantity);
    }

    public float GetTotal()
    {
        return CartManager.GetTotal();
    }

    public void PurchaseItems()
    {
        CartManager.PurchaseItems();
    }

    public void RemoveFromCart(Item removedItem)
    {
        CartManager.RemoveFromCart(removedItem);
    }

    public void ChangeItemQuantity(Item addedItem, int quantity)
    {
        CartManager.ChangeItemQuantity(addedItem, quantity);
    }
    public async Task<IEnumerable<ItemCategory>> GetItemCategoriesAsync()
    {
        return await CategoryManager.GetItemCategoriesAsync();
    }

    public async Task<bool> CheckoutAsync(Order order)
    {
        if (order.PlacedBy == null || order.PlacedBy.Equals(""))
        {
            return true;
        }
        else
        {
            order.Items = CartManager.GetCartItems().Keys.ToList();
            foreach (var orderItem in order.Items)
            {
                orderItem.Quantity = CartManager.GetCartItems()[orderItem];
            }
            bool orderSuccess = await OrderManager.AddOrderAsync(order);
            if (orderSuccess)
            {
                CartManager.ClearCart();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public async Task<List<Order>> GetAllOrdersForUser(string username)
    {
        return await OrderManager.GetAllOrdersForUser(username);
    }

    public async Task RefundOrderAsync(Order order)
    {
        await OrderManager.RefundOrderAsync(order);
    }

    public async Task ReturnOrderAsync(Order order, int credit)
    {
        await OrderManager.ReturnOrderAsync(order, credit);
    }
}