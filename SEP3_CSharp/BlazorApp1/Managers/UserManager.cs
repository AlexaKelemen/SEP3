using BlazorApp1.Services;
using DataTransferObjects;
using Entities;
using Proto;


namespace Managers;

public class UserManager : IUserManager
{
    private UserService.UserServiceClient stub;
    private readonly IUserService UserService;

    public UserManager(UserService.UserServiceClient stub, IUserService userService)
    {
        this.stub = stub;
        UserService = userService;
    }
    public async Task<User> GetUser(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }

        UserDTO response = await UserService.GetUserAsync(username);
        User user = new User
        {
            Username = response.Username,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.FirstName,
            Address = response.Address
        };
        return user;
    }

    public async Task SaveUserInfo(User user)
    {
        throw new NotImplementedException();
    }
}