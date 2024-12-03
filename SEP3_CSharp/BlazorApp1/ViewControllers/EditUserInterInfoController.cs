using Entities;
using Managers;
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
        return await manager.GetUser(username);
    }
}