namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for creating a new user, 
/// containing required information such as username and password.
/// </summary>
public class CreateUserDTO
{
    /// <summary>
    /// Gets or sets the username of the new user.
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    public required string Username { get; set; }

    /// <summary>
    /// Gets or sets the password for the new user.
    /// </summary>
    /// <remarks>
    /// This property is required. Ensure that the password is securely handled and not logged in plain text.
    /// </remarks>
    public required string Password { get; set; }
}
