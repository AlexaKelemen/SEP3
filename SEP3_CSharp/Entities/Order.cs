using System.Collections;

namespace Entities;

public class Order
{
    public int OrderId { get; set; }
    public double Price { get; set; }
    public DateTime PlacedOn { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public User PlacedBy { get; set; } = null!;
    public List<DeliveryOption> DeliveryOptions { get; set; } = [];
}