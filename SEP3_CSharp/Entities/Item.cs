using Entities.Utilities;

namespace Entities;

public class Item
{
    public int ItemId { get; set; }
    public string Colour {get; set;}
    public string Size {get; set;}
    public float Price { get; set; }
    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;
    
}