using Entities;

namespace BlazorApp1.Managers;

public interface IOrderManager
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    
    Task<bool> AddOrderAsync(Order order);
}