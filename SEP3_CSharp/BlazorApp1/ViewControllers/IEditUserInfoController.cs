using Entities;

namespace BlazorApp1.ViewControllers;

public interface IEditUserInfoController
{
     User getUser(string username, string password);
}