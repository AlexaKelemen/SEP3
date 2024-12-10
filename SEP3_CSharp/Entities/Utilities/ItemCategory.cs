namespace Entities.Utilities;

public class ItemCategory
{
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}