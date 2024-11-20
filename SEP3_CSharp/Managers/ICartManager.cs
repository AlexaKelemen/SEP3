using Entities;

namespace Managers.Server;

public interface ICartManager
{
    void AddToCart(Item addedItem, int quantity);
}