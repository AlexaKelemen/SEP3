using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DataTransferObjects;
using Entities;
using Proto;

namespace BlazorApp1.Managers;

public class UserManager : IUserManager
{
    private UserService.UserServiceClient Stub;
    private readonly IUserService UserService;

    public UserManager(UserService.UserServiceClient stub, IUserService userService)
    {
        this.Stub = stub;
        UserService = userService;
    }
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

    public async Task SaveUserInfoAsync(UserDTO userdto)
    {
        
        await UserService.UpdateUserAsync(userdto);
    }

    public async Task<int> GetCreditForUser(string username)
    {
        GetCreditRequest request = new GetCreditRequest()
        {
            User = username
        };
        var response = await Stub.getCreditForUserAsync(request);
        return response.Credit;
    }

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