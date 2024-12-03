using Entities;

namespace Managers;

public interface IUserManager
{
    User GetUser(string username);
    void SaveUserInfo(User user);
}