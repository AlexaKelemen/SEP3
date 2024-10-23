using System.Collections;

namespace Entities.Utilities;

public class Return
{
    public ArrayList items;
    public User User  { get; set; }
    public DateOnly ReturnDate { get; set; }
    public string Status { get; set; }
    public string Reason { get; set; }
}