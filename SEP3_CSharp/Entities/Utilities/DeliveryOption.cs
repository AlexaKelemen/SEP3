namespace Entities;

public class DeliveryOption
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}