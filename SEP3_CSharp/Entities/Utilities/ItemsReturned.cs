using System.Collections;

namespace Entities.Utilities;

public class ItemsReturned
{
    public int NumberReturned { get; set; }
    public float PercentageReturned { get; set; }
    public User Username { get; set; } = null!;

}