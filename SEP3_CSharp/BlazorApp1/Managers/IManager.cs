using DataTransferObjects;
using Entities;

namespace BlazorApp1.Managers;

public interface IManager
{
    Task<User> GetUser(string username);
    Task SaveUserInfo(UserDTO userdto);
    Task<ItemDTOs> GetProductById(int id);
}