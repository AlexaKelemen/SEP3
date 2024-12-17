using Azure.Core;
using DataTransferObjects;
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

    public async Task RefundOrderAsync(Order order)
    {
        
    }
    public async Task ReturnOrderAsync(Order order, int credit)
    {
        
    }

    public async Task<List<Order>> GetAllOrdersForUser(string username)
    {
        GetAllOrdersRequest request = new GetAllOrdersRequest()
        {
            User = username
        };
        var response = await Stub.getAllOrdersForUserAsync(request);
        List<Order> result = new List<Order>();
        foreach (OrderDTO order in response.Orders)
        {
            List<Item> items = new List<Item>();
            foreach (ItemDTO item in order.Items)
            {
                List<Category> categories = new List<Category>();
                foreach (CategoryDTO cat in item.Category)
                {
                   categories.Add(new Category()
                   {
                       CategoryId = cat.CategoryId,
                       CategoryDescription = cat.Description,
                       CategoryName = cat.Name
                   }); 
                }
                items.Add(new Item()
                {
                    CategoryId = categories,
                    Colour = item.Colour,
                    Description = item.Description,
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Price = (float)item.Price,
                    Quantity = item.Quantity
                });
            }

            result.Add(new Order()
            {
                OrderId = order.OrderId,
                PlacedBy = order.PlacedBy,
                PlacedOn = order.PlacedOn.ToDateTime(),
                Price = order.TotalAmount,
                DeliveryOption = new DeliveryOption()
                {
                    Id = order.DeliveryOption.Id,
                    Name = order.DeliveryOption.Name,
                    ToAddress = order.ToAddress
                },
                PaymentMethod = new PaymentMethod()
                {
                    Id = order.PaymentMethod.Id,
                    Name = order.PaymentMethod.Name
                },
                Items = items
            });
        }
        return result;
    }
}