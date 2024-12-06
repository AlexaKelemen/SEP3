using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

public interface IUserManager
{
    Task<User> GetUser(string username);
    Task SaveUserInfo(UserDTO userdto);
}