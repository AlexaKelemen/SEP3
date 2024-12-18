using System.Collections;

namespace Entities;

public class Order
{
    public int OrderId { get; set; }
    public double Price { get; set; }
    public DateTime PlacedOn { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public string PlacedBy { get; set; }  
    public DeliveryOption DeliveryOption { get; set; }

    public List<Item> Items { get; set; }

    public bool IsNew()
    {
        DateTime temp = PlacedOn.AddDays(30);
        if (DateTime.Compare(DateTime.Now, temp) > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}