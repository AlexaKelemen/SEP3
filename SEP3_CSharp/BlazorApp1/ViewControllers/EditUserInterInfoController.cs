using BlazorApp1.Managers;
using Entities;
//using SourceCode;

namespace BlazorApp1.ViewControllers;

public class EditUserInterInfoController : IEditUserInfoController
{
    private IManager manager;
    
    public EditUserInterInfoController(Manager manager)
    {
        this.manager = manager;
    }
    
    public async Task<User> getUser(string username)
    {
        return await manager.GetUserAsync(username);
    }
}