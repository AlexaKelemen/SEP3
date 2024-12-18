using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

/// <summary>
/// Defines methods for managing orders, including adding, refunding, returning, and retrieving orders for a user.
/// </summary>
public interface IOrderManager
{
    /// <summary>
    /// Adds a new order asynchronously.
    /// </summary>
    /// <param name="order">The order to be added.</param>
    Task<bool> AddOrderAsync(Order order);

    /// <summary>
    /// Refunds an existing order asynchronously.
    /// </summary>
    /// <param name="order">The order to be refunded.</param>
    Task RefundOrderAsync(Order order);

    /// <summary>
    /// Returns an order and applies credit asynchronously.
    /// </summary>
    /// <param name="order">The order to be returned.</param>
    /// <param name="credit">The amount of credit to apply after the return.</param>
    Task ReturnOrderAsync(Order order, int credit);

    /// <summary>
    /// Retrieves all orders for a specific user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user whose orders are to be fetched.</param>
    Task<List<Order>> GetAllOrdersForUser(string username);
}
