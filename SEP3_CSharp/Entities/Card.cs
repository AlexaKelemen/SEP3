namespace Entities;

public class Card
{
    public int CardId { get; set; }
    public string CardNumber { get; set; } = null!;
    public DateOnly ExpirationDate { get; set; }
    public int Cvc { get; set; }
    public User FirstName { get; set; } = null!;
    public User LastName { get; set; } = null!;
    public User Username { get; set; } = null!;
}