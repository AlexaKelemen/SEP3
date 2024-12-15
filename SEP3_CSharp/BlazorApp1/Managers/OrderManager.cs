using Azure.Core;
using Entities;
using Entities.Utilities;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
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

    public async Task<bool> AddOrderAsync(Order order)
    {
        DateTime replacementDate = DateTime.SpecifyKind(order.PlacedOn, DateTimeKind.Utc);
        GetOrderRequest request = new GetOrderRequest()
        {
            DeliveryOption = new DeliveryOptionDTO()
            {
                Id = order.DeliveryOption.Id,
                Name = order.DeliveryOption.Name
            },
            PaymentMethod = new PaymentMethodDTO()
            {
                Id = order.PaymentMethod.Id,
                Name = order.PaymentMethod.Name
            },
            PlacedOn = replacementDate.ToTimestamp(),
            TotalAmount = order.Price,
            OrderId = order.OrderId,
            PlacedBy = order.PlacedBy,
            ToAddress = order.DeliveryOption.ToAddress
        };
        order.Items.ForEach(item =>
        {
            ItemDTO temp = new ItemDTO()
            {
                Colour = item.Colour,
                Description = item.Description,
                ItemId = item.ItemId,
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity
            };
            item.CategoryId.ForEach(cat =>
            {
                temp.Category.Add(new CategoryDTO()
                {
                    CategoryId = cat.CategoryId,
                    Description = cat.CategoryDescription,
                    Name = cat.CategoryName
                });
            });
            request.Items.Add(temp);
        });
        var response = await Stub.addOrderAsync(request);
        return response.Success;
    }
}