using Entities;

namespace BlazorApp1.ViewControllers;

public interface IEditUserInfoController
{
     Task<User> getUser(string username);
}