using Entities;
using Grpc.Net.Client;
using SourceCode;

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
    public User getUser(string username, string password)
    {
        return UserManager.getUser(username, password);
    }
}