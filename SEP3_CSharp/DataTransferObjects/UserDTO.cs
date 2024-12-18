namespace DataTransferObjects;
using Entities;

/// <summary>
/// Represents a Data Transfer Object (DTO) for a user, containing personal and payment information
/// </summary>
public class UserDTO
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the billing address of the user.
    /// </summary>
    public string BillingAddress { get; set; }

    /// <summary>
    /// Gets or sets the card information associated with the user.
    /// </summary>
    /// <remarks>
    /// This property is optional and may be null.
    /// </remarks>
    public Card? Card { get; set; }
}
