namespace DataTransferObjects;

/// <summary>
/// Represents a Data Transfer Object (DTO) for a login request, containing what is required for user authentication. 
/// </summary>
public class LoginRequestDTO
{
    /// <summary>
    /// Gets or sets the username of the user attempting to log in.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password of the user attempting to log in.
    /// </summary>
    public string Password { get; set; }
}
