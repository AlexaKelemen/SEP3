using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

public interface IUserManager
{
    Task<User> GetUserAsync(string username);
    Task SaveUserInfoAsync(UserDTO userdto);
    Task<int> GetCreditForUser(string username);
    Task SetCreditForUser(string username, int credit);
}