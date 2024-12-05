using System.Text.RegularExpressions;

namespace Entities;

public class Card
{
    public int CardId { get; set; }
    public string CardNumber { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public string Cvc { get; set; }
    public string FName { get; set; } = null!;
    public string LName { get; set; } = null!;
    public string Username { get; set; } = null!;
}