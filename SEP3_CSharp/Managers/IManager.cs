using Entities;

namespace Managers;

public interface IManager
{
    User getUser(string username, string password);
}