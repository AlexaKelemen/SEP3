namespace Entities;

public class Card
{
    public int CardId { get; set; }
    public string CardNumber { get; set; } = null!;
    public DateOnly ExpirationDate { get; set; }
    public int Cvc { get; set; }
    public String FirstName { get; set; } = null!;
    public String LastName { get; set; } = null!;
    public String Username { get; set; } = null!;
}