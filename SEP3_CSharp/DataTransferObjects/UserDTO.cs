namespace DataTransferObjects;
using Entities;

public class UserDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string BillingAddress { get; set; }
    public Card? Card { get; set; } 
}