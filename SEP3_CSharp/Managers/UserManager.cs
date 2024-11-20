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
        GetUserResponse response = stub.getUser(new GetUserRequest(){Password = password, Username = username});
        User user = new User
        {
            Username = response.Username,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.FirstName,
            ShippingAddress = response.ShippingAddress,
            BillingAddress = response.BillingAddress,
            PaymentInformation = response.PaymentInformation
        };
        return user;
    }
}