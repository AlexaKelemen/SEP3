using Entities;
using Grpc.Net.Client;
using Proto;



namespace Managers;

public class Manager : IManager
{
    private IUserManager UserManager;
    private UserService.UserServiceClient stub;

    public Manager(GrpcChannel channel)
    {
        var stub = new UserService.UserServiceClient(channel);
        UserManager = new UserManager(stub);
        
    }
    public User GetUser(string username)
    {
        return UserManager.GetUser(username);
    }

    public void SaveUserInfo(User user)
    {
        UserManager.SaveUserInfo(user);
    }
}