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
    public User getUser(string username)
    {
        return UserManager.getUser(username);
    }
}