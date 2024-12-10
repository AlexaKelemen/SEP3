using BlazorApp1.Services;
using BlazorApp1.Services.Contracts;
using DatabaseConnection;
using DataTransferObjects;
using Entities;
using Entities.Utilities;
using Grpc.Net.Client;
using Proto;



namespace BlazorApp1.Managers;

public class Manager : IManager
{
    private IUserManager UserManager;
    
    private UserService.UserServiceClient stub;

    private IUserService UserService;
    
    private IItemManager ItemManager;
    
    private CategoryManager CategoryManager;
    

    public Manager(GrpcChannel channel, IUserService userService, IItemService itemService, ICategoryService categoryService)
    {
        var stub = new UserService.UserServiceClient(channel);
        
        UserManager = new UserManager(stub, userService);
        ItemManager = new ItemManager(itemService);
        CategoryManager = new CategoryManager(categoryService);
    }
    public async Task<User> GetUserAsync(string username)
    {
        return await UserManager.GetUserAsync(username);
    }

    public async Task SaveUserInfoAsync(UserDTO userdto)
    {
        await UserManager.SaveUserInfoAsync(userdto);
    }

    public async Task<ItemDTOs> GetProductByIdAsync(int productId)
    {
       return await ItemManager.GetItemAsync(productId);
    }

    public async Task<IEnumerable<ItemDTOs>> GetItemsAsync()
    {
        return await ItemManager.GetItemsAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await CategoryManager.GetCategoriesAsync();
    }
}