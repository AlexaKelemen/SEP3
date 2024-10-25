using Entities;

namespace Managers;

public interface IUserManager
{
    User getUser(string username, string password);
}