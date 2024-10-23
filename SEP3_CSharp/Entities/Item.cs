using Entities.Utilities;

namespace Entities;

public class Item
{
    public string ItemType { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    
}