using Entities;
using Proto;


namespace Managers;

public class UserManager : IUserManager
{
    private UserService.UserServiceClient stub;

    public UserManager(UserService.UserServiceClient stub)
    {
        this.stub = stub;
    }
    public User getUser(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }

        GetUserResponse response = stub.getUser(new GetUserRequest(){ Username = username});
        User user = new User
        {
            Username = response.Username,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.FirstName,
            Address = response.BillingAddress
        };
        return user;
    }
}