using System.Text.RegularExpressions;

namespace DataTransferObjects;

public class CardDTO
{
    public string CardNumber 
    {
        get
        {
            return CardNumber;
        }
        set
        {
            if (!Regex.IsMatch(value, @"^\d{16}$"))
                throw new FormatException("Input must consist of exactly 16 digits.");
            CardNumber = value;
        } } 
    public DateOnly ExpirationDate { get; set; }
    public int Cvc { get; set; }
    public String FirstName { get; set; } = null!;
    public String LastName { get; set; } = null!;
}