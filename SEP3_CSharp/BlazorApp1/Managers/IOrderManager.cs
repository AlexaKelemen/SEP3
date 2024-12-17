using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

public interface IOrderManager
{
    
    Task<bool> AddOrderAsync(Order order);
    Task RefundOrderAsync(Order order);
    Task ReturnOrderAsync(Order order, int credit);

    Task<List<Order>> GetAllOrdersForUser(string username);
}