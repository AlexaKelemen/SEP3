using Entities;

namespace BlazorApp1.Managers;

public interface IOrderManager
{
    Task<IEnumerable<Order>> GetOrdersAsync();
}