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
            if (string.IsNullOrEmpty(Cvc) || Cvc.Length != 16 || !IsDigitsOnly(Cvc))
            {
                throw new ArgumentException("The input must be a string of exactly 3 digits.");
            }
        } } 
    public DateOnly ExpirationDate { get; set; }

    public string Cvc
    {
        get
        {
            return Cvc;
        }
        set
        {
            if (string.IsNullOrEmpty(Cvc) || Cvc.Length != 3 || !IsDigitsOnly(Cvc))
            {
                throw new ArgumentException("The input must be a string of exactly 3 digits.");
            }
        }
    }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    
    private bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}