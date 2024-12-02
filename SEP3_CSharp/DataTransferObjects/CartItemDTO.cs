namespace DataTransferObjects;

public class CartItemDTO
{
    public int ItemId { get; set; }
    public string Colour { get; set; }
    public string Size { get; set; }
    public float Price { get; set; }
    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;


    public int Quantity { get; set; }
}