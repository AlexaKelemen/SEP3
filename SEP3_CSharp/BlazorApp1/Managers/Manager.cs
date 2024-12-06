using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Grpc.Net.Client;
using Proto;



namespace BlazorApp1.Managers;

public class Manager : IManager
{
    private IUserManager UserManager;
    
    private UserService.UserServiceClient stub;

    private IUserService UserService;
    
    private IItemManager ItemManager;
    
    

    public Manager(GrpcChannel channel, IUserService userService, AppDbContext dbContext, IItemService itemService)
    {
        var stub = new UserService.UserServiceClient(channel);
        
        UserManager = new UserManager(stub, userService);
        ItemManager = new ItemManager(dbContext, itemService);

    }
    public async Task<User> GetUser(string username)
    {
        return await UserManager.GetUser(username);
    }

    public async Task SaveUserInfo(UserDTO userdto)
    {
        await UserManager.SaveUserInfo(userdto);
    }

    public async Task<ItemDTOs> GetProductById(int productId)
    {
       return await ItemManager.GetItem(productId);
    }

    public async Task<IEnumerable<ItemDTOs>> GetItems()
    {
        return await ItemManager.GetItems();
    }
}