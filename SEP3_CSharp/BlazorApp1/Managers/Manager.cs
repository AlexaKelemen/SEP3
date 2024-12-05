using BlazorApp1.Services;
using DataTransferObjects;
using Entities;
using Grpc.Net.Client;
using Proto;



namespace Managers;

public class Manager : IManager
{
    private IUserManager UserManager;
    
    private UserService.UserServiceClient stub;

    private IUserService UserService;

    public Manager(GrpcChannel channel, IUserService userService)
    {
        var stub = new UserService.UserServiceClient(channel);
        
        UserManager = new UserManager(stub, userService);
        
    }
    public async Task<User> GetUser(string username)
    {
        return await UserManager.GetUser(username);
    }

    public async Task SaveUserInfo(UserDTO userdto)
    {
        await UserManager.SaveUserInfo(userdto);
    }
}