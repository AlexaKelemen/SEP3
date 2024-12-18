using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Proto;

namespace BlazorApp1.Managers;

/// <summary>
/// Manages user-related operations such as fetching user details, saving user information, and handling user credit.
/// </summary>
public class UserManager : IUserManager
{
    private UserService.UserServiceClient Stub;
    private readonly IUserService UserService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserManager"/> class.
    /// </summary>
    /// <param name="stub">The "UserService.UserServiceClient" used to interact with the gRPC user service.</param>
    /// <param name="userService">The "IUserService" for interacting with the user service API.</param>
    public UserManager(UserService.UserServiceClient stub, IUserService userService)
    {
        this.Stub = stub;
        UserService = userService;
    }

    /// <summary>
    /// Retrieves a user's details based on their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve information for.</param>
    /// <returns>A "User" object containing the user's details.</returns>
    public async Task<User> GetUserAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }

        UserDTO response = await UserService.GetUserAsync(username, true);
        User user = new User
        {
            Username = response.Username,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.LastName,
            BillingAddress = response.BillingAddress,
            Card = response.Card
        };
        return user;
    }

    /// <summary>
    /// Saves the provided user information.
    /// </summary>
    /// <param name="userdto">A "UserDTO"object containing the updated user information.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SaveUserInfoAsync(UserDTO userdto)
    {
        await UserService.UpdateUserAsync(userdto);
    }

    /// <summary>
    /// Retrieves the credit balance for a specified user.
    /// </summary>
    /// <param name="username">The username of the user to retrieve the credit balance for.</param>
    /// <returns>An integer representing the user's credit balance.</returns>
    public async Task<int> GetCreditForUser(string username)
    {
        GetCreditRequest request = new GetCreditRequest()
        {
            User = username
        };
        var response = await Stub.getCreditForUserAsync(request);
        return response.Credit;
    }

    /// <summary>
    /// Sets the credit balance for a specified user.
    /// </summary>
    /// <param name="username">The username of the user to set the credit for.</param>
    /// <param name="credit">The new credit balance for the user.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SetCreditForUser(string username, int credit)
    {
        SetCreditRequest request = new SetCreditRequest()
        {
            User = username,
            Credit = credit
        };
        var response = await Stub.setCreditForUserAsync(request);
    }
}
