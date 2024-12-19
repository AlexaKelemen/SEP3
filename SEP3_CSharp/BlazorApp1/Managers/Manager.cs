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

/// <summary>
/// The main manager class that deals with  user management, item management, category management, cart management, and order processing.
/// </summary>
public class Manager : IManager
{
    private IUserManager UserManager;
    private UserService.UserServiceClient stub;
    private IUserService UserService;
    private IItemManager ItemManager;
    private ICategoryManager CategoryManager;
    private ICartManager CartManager;
    private IOrderManager OrderManager;

    /// <summary>
    /// Initializes a new instance of the "Manager" class.
    /// This constructor is used when creating an instance without dependencies being passed.
    /// </summary>
    public Manager()
    {
    }

    /// <summary>
    /// Initializes a new instance of the "Manager" class with the specified gRPC channel, user service, item service, and category service.
    /// </summary>
    /// <param name="channel">The gRPC channel used for communication.</param>
    /// <param name="userService">The user service instance for interacting with user-related operations.</param>
    /// <param name="itemService">The item service instance for managing items.</param>
    /// <param name="categoryService">The category service instance for managing categories.</param>
    public Manager(GrpcChannel channel, IUserService userService, IItemService itemService, ICategoryService categoryService)
    {
        var stub = new UserService.UserServiceClient(channel);

        UserManager = new UserManager(stub, userService);
        ItemManager = new ItemManager(itemService);
        CategoryManager = new CategoryManager(categoryService);
        CartManager = new CartManager();
        OrderManager = new OrderManager(stub);
    }

    /// <summary>
    /// Retrieves a user based on the specified username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>A "Task" representing the asynchronous operation, with a "User" as the result.</returns>
    public async Task<User> GetUserAsync(string username)
    {
        return await UserManager.GetUserAsync(username);
    }

    /// <summary>
    /// Saves the user information.
    /// </summary>
    /// <param name="userdto">The user data transfer object containing user information.</param>
    /// <returns>A "Task" representing the asynchronous operation.</returns>
    public async Task SaveUserInfoAsync(UserDTO userdto)
    {
        await UserManager.SaveUserInfoAsync(userdto);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="productId">The ID of the product to retrieve.</param>
    /// <returns>A "Task" representing the asynchronous operation, with an "ItemDTOs" as the result.</returns>
    public async Task<ItemDTOs> GetProductByIdAsync(int productId)
    {
        return await ItemManager.GetItemAsync(productId);
    }

    /// <summary>
    /// Retrieves all items.
    /// </summary>
    /// <returns>A "Task" representing the asynchronous operation, with an "IEnumerable{ItemDTOs}" as the result.</returns>
    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await ItemManager.GetItemsAsync();
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A "Task" representing the asynchronous operation, with an "IEnumerable{Category}" as the result.</returns>
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await CategoryManager.GetCategoriesAsync();
    }

    /// <summary>
    /// Retrieves the items currently in the user's cart.
    /// </summary>
    /// <returns>A dictionary of items and their respective quantities in the cart.</returns>
    public Dictionary<Item, int> GetCartItems()
    {
        return CartManager.GetCartItems();
    }

    /// <summary>
    /// Adds an item to the user's cart with a specified quantity.
    /// </summary>
    /// <param name="addedItem">The item to add to the cart.</param>
    /// <param name="quantity">The quantity of the item to add.</param>
    public void AddToCart(Item addedItem, int quantity)
    {
        CartManager.AddToCart(addedItem, quantity);
    }

    /// <summary>
    /// Retrieves the total price of items in the user's cart.
    /// </summary>
    /// <returns>The total price of the items in the cart.</returns>
    public float GetTotal()
    {
        return CartManager.GetTotal();
    }

    /// <summary>
    /// Purchases all items currently in the user's cart.
    /// </summary>
    public void PurchaseItems()
    {
        CartManager.PurchaseItems();
    }

    /// <summary>
    /// Removes an item from the user's cart.
    /// </summary>
    /// <param name="removedItem">The item to remove from the cart.</param>
    public void RemoveFromCart(Item removedItem)
    {
        CartManager.RemoveFromCart(removedItem);
    }

    /// <summary>
    /// Changes the quantity of an item in the user's cart.
    /// </summary>
    /// <param name="addedItem">The item whose quantity is to be changed.</param>
    /// <param name="quantity">The new quantity of the item.</param>
    public void ChangeItemQuantity(Item addedItem, int quantity)
    {
        CartManager.ChangeItemQuantity(addedItem, quantity);
    }

    /// <summary>
    /// Retrieves all item categories.
    /// </summary>
    /// <returns>A "Task" representing the asynchronous operation, with an "IEnumerable{ItemCategory}" as the result.</returns>
    public async Task<IEnumerable<ItemCategory>> GetItemCategoriesAsync()
    {
        return await CategoryManager.GetItemCategoriesAsync();
    }

    /// <summary>
    /// Performs the checkout process, placing an order with the items in the cart.
    /// </summary>
    /// <param name="order">The order to be placed.</param>
    /// <returns>A "Task" representing the asynchronous operation, with a boolean indicating if the checkout was successful.</returns>
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

    /// <summary>
    /// Retrieves all orders for a specific user.
    /// </summary>
    /// <param name="username">The username of the user whose orders are to be retrieved.</param>
    /// <returns>A "Task" representing the asynchronous operation, with a list of "Order" objects as the result.</returns>
    public async Task<List<Order>> GetAllOrdersForUser(string username)
    {
        return await OrderManager.GetAllOrdersForUser(username);
    }

    /// <summary>
    /// Processes a refund for a given order.
    /// </summary>
    /// <param name="order">The order to be refunded.</param>
    /// <returns>A "Task" representing the asynchronous operation.</returns>
    public async Task RefundOrderAsync(Order order)
    {
        await OrderManager.RefundOrderAsync(order);
    }

    /// <summary>
    /// Processes the return of a given order and applies the specified credit.
    /// </summary>
    /// <param name="order">The order to be returned.</param>
    /// <param name="credit">The amount of credit to be applied upon return.</param>
    /// <returns>A "Task" representing the asynchronous operation.</returns>
    public async Task ReturnOrderAsync(Order order, int credit)
    {
        await OrderManager.ReturnOrderAsync(order, credit);
    }

    /// <summary>
    /// Retrieves the credit for a specific user.
    /// </summary>
    /// <param name="username">The username of the user whose credit is to be retrieved.</param>
    /// <returns>A "Task" representing the asynchronous operation, with the credit amount as the result.</returns>
    public async Task<int> GetCreditForUser(string username)
    {
        return await UserManager.GetCreditForUser(username);
    }

    /// <summary>
    /// Sets the credit for a specific user.
    /// </summary>
    /// <param name="username">The username of the user whose credit is to be updated.</param>
    /// <param name="credit">The new credit value to set.</param>
    /// <returns>A "Task" representing the asynchronous operation.</returns>
    public async Task SetCreditForUser(string username, int credit)
    {
        await UserManager.SetCreditForUser(username, credit);
    }
}
