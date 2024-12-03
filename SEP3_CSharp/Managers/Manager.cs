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
    public async Task<User> GetUser(string username)
    {
        return await UserManager.GetUser(username);
    }

    public async Task SaveUserInfo(User user)
    {
        await UserManager.SaveUserInfo(user);
    }
}