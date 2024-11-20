using Entities;
using SourceCode;

namespace Managers;

public class UserManager : IUserManager
{
    private UserService.UserServiceClient stub;

    public UserManager(UserService.UserServiceClient stub)
    {
        this.stub = stub;
    }
    public User getUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        }

        GetUserResponse response = stub.getUser(new GetUserRequest(){Password = password, Username = username});
        User user = new User
        {
            Username = response.Username,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.FirstName,
            ShippingAddress = response.ShippingAddress,
            BillingAddress = response.BillingAddress,
            Address = response.BillingAddress,
            PaymentInformation = response.PaymentInformation
        };
        return user;
    }
}