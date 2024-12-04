using DataTransferObjects;
using Entities;

namespace Managers;

public interface IManager
{
    Task<User> GetUser(string username);
    Task SaveUserInfo(UserDTO userdto);
}