using Entities;

namespace Managers;

public interface IManager
{
    User GetUser(string username);
    void SaveUserInfo(User user);
}