namespace DataTransferObjects;

public class CartItemToAddDTO
{
    public int CartId { get; set; }
    public int ItemId { get; set; }
    public int Quantity{ get; set; }
}