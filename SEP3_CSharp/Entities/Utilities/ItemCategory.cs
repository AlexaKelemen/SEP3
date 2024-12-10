using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Utilities;

public class ItemCategory
{
    public Item ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public Category CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}