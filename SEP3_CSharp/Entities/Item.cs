using Entities.Utilities;

namespace Entities;

public class Item
{
    public int ItemId { get; set; }
    public float Price { get; set; }
    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;
    
}