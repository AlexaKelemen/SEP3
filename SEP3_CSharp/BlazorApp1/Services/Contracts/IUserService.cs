namespace BlazorApp1.Services;
using DataTransferObjects;

/// <summary>
/// Defines the contract for a service that manages user-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <param name="request">The user details to be added.</param>
    /// <returns>The created user details.</returns>
    Task<UserDTO> AddUserAsync(CreateUserDTO request);

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <param name="cardIncluded">Indicates whether to include the user's card information in the response.</param>
    /// <returns>The requested user details.</returns>
    Task<UserDTO> GetUserAsync(string username, bool cardIncluded);

    /// <summary>
    /// Retrieves a list of all users in the system.
    /// </summary>
    /// <returns>A list of all user details.</returns>
    Task<List<UserDTO>> GetUsersAsync();

    /// <summary>
    /// Updates an existing user's details.
    /// </summary>
    /// <param name="request">The updated user details.</param>
    Task UpdateUserAsync(UserDTO request);
}
