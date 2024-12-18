using Azure.Core;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Proto;

namespace BlazorApp1.Managers;

/// <summary>
/// Manages order-related operations such as adding orders, processing refunds, returning orders, and retrieving orders for a user.
/// </summary>
public class OrderManager : IOrderManager
{
    private UserService.UserServiceClient Stub;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderManager"/> class.
    /// </summary>
    /// <param name="stub">The "UserService.UserServiceClient" used to interact with the gRPC order service.</param>
    public OrderManager(UserService.UserServiceClient stub)
    {
        Stub = stub;
    }

    /// <summary>
    /// Adds a new order to the system.
    /// </summary>
    /// <param name="order">The order to be added.</param>
    /// <returns>A boolean indicating whether the order was successfully added.</returns>
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
                Quantity = item.Quantity,
                Size = item.Size
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

    /// <summary>
    /// Refunds a given order.
    /// </summary>
    /// <param name="order">The order to be refunded.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RefundOrderAsync(Order order)
    {
        DateTime replacementDate = DateTime.SpecifyKind(order.PlacedOn, DateTimeKind.Utc);
        GetRefundOrderRequest request = new GetRefundOrderRequest()
        {
            Order = new OrderDTO()
            {
                DeliveryOption = new DeliveryOptionDTO()
                {
                    Id = order.DeliveryOption.Id,
                    Name = order.DeliveryOption.Name
                },
                OrderId = order.OrderId,
                PaymentMethod = new PaymentMethodDTO()
                {
                    Id = order.PaymentMethod.Id,
                    Name = order.PaymentMethod.Name
                },
                PlacedBy = order.PlacedBy,
                ToAddress = order.DeliveryOption.ToAddress,
                TotalAmount = order.Price,
                PlacedOn = replacementDate.ToTimestamp()
            }
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
                Quantity = item.Quantity,
                Size = item.Size
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
            request.Order.Items.Add(temp);
        });

        var response = await Stub.refundAnOrderAsync(request);
    }

    /// <summary>
    /// Processes the return of a given order and applies the specified credit.
    /// </summary>
    /// <param name="order">The order to be returned.</param>
    /// <param name="credit">The amount of credit to be applied upon return.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ReturnOrderAsync(Order order, int credit)
    {
        DateTime replacementDate = DateTime.SpecifyKind(order.PlacedOn, DateTimeKind.Utc);
        GetReturnOrderRequest request = new GetReturnOrderRequest()
        {
            Order = new OrderDTO()
            {
                DeliveryOption = new DeliveryOptionDTO()
                {
                    Id = order.DeliveryOption.Id,
                    Name = order.DeliveryOption.Name
                },
                OrderId = order.OrderId,
                PaymentMethod = new PaymentMethodDTO()
                {
                    Id = order.PaymentMethod.Id,
                    Name = order.PaymentMethod.Name
                },
                PlacedBy = order.PlacedBy,
                ToAddress = order.DeliveryOption.ToAddress,
                TotalAmount = order.Price,
                PlacedOn = replacementDate.ToTimestamp()
            },
            Credit = credit
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
                Quantity = item.Quantity,
                Size = item.Size
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
            request.Order.Items.Add(temp);
        });

        var response = await Stub.returnAnOrderAsync(request);
    }

    /// <summary>
    /// Retrieves all orders for a specific user.
    /// </summary>
    /// <param name="username">The username of the user whose orders are to be retrieved.</param>
    /// <returns>A list of "Order" objects representing the user's orders.</returns>
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
                    Quantity = item.Quantity,
                    Size = item.Size
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
