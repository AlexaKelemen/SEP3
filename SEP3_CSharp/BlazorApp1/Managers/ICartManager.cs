using Entities;

namespace Managers.Server;

public interface ICartManager
{
    void AddToCart(Item addedItem, int quantity);
    void RemoveFromCart(Item removedItem, int quantity);
    void ClearCart();
    float GetTotal();
}