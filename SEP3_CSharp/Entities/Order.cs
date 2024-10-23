namespace Entities;

public class Order
{
    public DateOnly Date { get; set; }
    public string PaymentMethod { get; set; }
    public float TotalAmount { get; set; }
    public string DeliveryOption { get; set; }
}