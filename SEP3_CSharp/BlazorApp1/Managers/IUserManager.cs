using Entities;

namespace Managers;

public interface IUserManager
{
    Task<User> GetUser(string username);
    Task SaveUserInfo(User user);
}