using System.Collections;
using System.ComponentModel.DataAnnotations;
using Entities.Utilities;

namespace Entities;

public class User
{
    [Key]
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string BillingAddress { get; set; } = null!;
    public Card? Card { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}