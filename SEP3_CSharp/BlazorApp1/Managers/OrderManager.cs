using Azure.Core;
using Entities;
using Google.Protobuf.Collections;
using Proto;

namespace BlazorApp1.Managers;

public class OrderManager : IOrderManager
{
    private UserService.UserServiceClient Stub;
    public OrderManager(UserService.UserServiceClient stub)
    {
        Stub = stub;
    }
    public Task<IEnumerable<Order>> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddOrderAsync(Order order)
    {
        RepeatedField<ItemDTO> items = new RepeatedField<ItemDTO>();
        order.Items.ForEach(item => items.Add(new ItemDTO()
        {
            
        }));
        Stub.addOrderAsync(new GetOrderRequest()
        {
            DeliveryOption = order.DeliveryOptions.FirstOrDefault().Id,
            
        });
        throw new NotImplementedException();
    }
}