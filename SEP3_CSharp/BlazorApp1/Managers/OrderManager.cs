using Entities;

namespace BlazorApp1.Managers;

public class OrderManager : IOrderManager
{
    public Task<IEnumerable<Order>> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }
}