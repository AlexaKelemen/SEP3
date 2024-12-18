using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

/// <summary>
/// Interface that defines the methods for managing user-related operations.
/// </summary>
public interface IUserManager
{
    /// <summary>
    /// Retrieves a user based on the specified username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    Task<User> GetUserAsync(string username);

    /// <summary>
    /// Saves the user information.
    /// </summary>
    /// <param name="userdto">The user data transfer object containing the user details to be saved.</param>
    Task SaveUserInfoAsync(UserDTO userdto);

    /// <summary>
    /// Retrieves the credit for the specified user.
    /// </summary>
    /// <param name="username">The username of the user whose credit is to be retrieved.</param>
    Task<int> GetCreditForUser(string username);

    /// <summary>
    /// Sets the credit for the specified user.
    /// </summary>
    /// <param name="username">The username of the user whose credit is to be updated.</param>
    /// <param name="credit">The amount of credit to set for the user.</param>
    Task SetCreditForUser(string username, int credit);
}
