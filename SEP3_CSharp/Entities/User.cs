using System.Collections;
using Entities.Utilities;

namespace Entities;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public string PaymentInformation { get; set; }
    public Cart Cart { get; set; }
    public ArrayList orders;
    public Credit Credit { get; set; }
    
}