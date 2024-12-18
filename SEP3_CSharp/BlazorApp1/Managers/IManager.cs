using DataTransferObjects;
using Entities;
using Entities.Utilities;

namespace BlazorApp1.Managers;

/// <summary>
/// Defines the main operations for managing users, products, categories, cart items, and orders.
/// </summary>
public interface IManager
{
    /// <summary>
    /// Retrieves a user by their username asynchronously.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    Task<User> GetUserAsync(string username);

    /// <summary>
    /// Saves user information asynchronously.
    /// </summary>
    /// <param name="userdto">The user information to be saved.</param>
    Task SaveUserInfoAsync(UserDTO userdto);

    /// <summary>
    /// Retrieves a product by its ID asynchronously.
    /// </summary>
    /// <param name="id">The product ID.</param>
    Task<ItemDTOs> GetProductByIdAsync(int id);

    /// <summary>
    /// Retrieves a list of all products asynchronously.
    /// </summary>
    Task<IEnumerable<ItemDTOs>> GetItemsAsync();

    /// <summary>
    /// Retrieves a list of all categories asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation, with an <see cref="IEnumerable{Category}"/> containing the categories.</returns>
    Task<IEnumerable<Category>> GetCategoriesAsync();

    /// <summary>
    /// Retrieves the current items in the cart.
    /// </summary>
    Dictionary<Item, int> GetCartItems();

    /// <summary>
    /// Adds a specified quantity of an item to the cart.
    /// </summary>
    /// <param name="addedItem">The item to be added to the cart.</param>
    /// <param name="quantity">The quantity of the item to be added.</param>
    void AddToCart(Item addedItem, int quantity);

    /// <summary>
    /// Retrieves the total cost of the items in the cart.
    /// </summary>
    /// <returns>A <see cref="float"/> representing the total cost of the cart items.</returns>
    float GetTotal();

    /// <summary>
    /// Processes the purchase of the items in the cart.
    /// </summary>
    void PurchaseItems();

    /// <summary>
    /// Removes an item from the cart.
    /// </summary>
    /// <param name="addedItem">The item to be removed from the cart.</param>
    void RemoveFromCart(Item addedItem);

    /// <summary>
    /// Changes the quantity of a specified item in the cart.
    /// </summary>
    /// <param name="addedItem">The item to update the quantity for.</param>
    /// <param name="quantity">The new quantity of the item in the cart.</param>
    void ChangeItemQuantity(Item addedItem, int quantity);

    /// <summary>
    /// Retrieves a list of item categories asynchronously.
    /// </summary>
    Task<IEnumerable<ItemCategory>> GetItemCategoriesAsync();

    /// <summary>
    /// Processes the checkout for an order asynchronously.
    /// </summary>
    /// <param name="order">The order to be processed for checkout.</param>
    Task<bool> CheckoutAsync(Order order);

    /// <summary>
    /// Refunds an order asynchronously.
    /// </summary>
    /// <param name="order">The order to be refunded.</param>
    Task RefundOrderAsync(Order order);

    /// <summary>
    /// Returns an order and applies credit asynchronously.
    /// </summary>
    /// <param name="order">The order to be returned.</param>
    /// <param name="credit">The credit amount to apply after returning the order.</param>
    Task ReturnOrderAsync(Order order, int credit);

    /// <summary>
    /// Retrieves a list of all orders for a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user whose orders need to be retrieved.</param>
    Task<List<Order>> GetAllOrdersForUser(string username);

    /// <summary>
    /// Retrieves the current credit for a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    Task<int> GetCreditForUser(string username);

    /// <summary>
    /// Sets the credit for a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="credit">The credit amount to be set for the user.</param>
    Task SetCreditForUser(string username, int credit);
}
