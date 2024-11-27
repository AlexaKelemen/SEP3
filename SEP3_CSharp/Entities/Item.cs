using Entities.Utilities;

namespace Entities;

public class Item
{
    public int ItemId { get; set; }
    public string Colour { get; set; }
    public string Size { get; set; }
    public float Price { get; set; }
    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<Category> CategoryId { get; set; } = new List<Category>();

    public override bool Equals(object? obj)
    {
        if (obj is Item otherItem)
        {
            return this.ItemId == otherItem.ItemId &&
                   this.Colour == otherItem.Colour &&
                   this.Size == otherItem.Size &&
                   this.Price == otherItem.Price &&
                   this.Description == otherItem.Description &&
                   this.Name == otherItem.Name;
        }

        return false;
    }
}