namespace Entities;

public class DeliveryOption
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ToAddress { get; set; }
    public string Speed { get; set; }
}